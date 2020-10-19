using Saga.Poc.Saga.Core.Events;
using Saga.Poc.Saga.Fin.App.Commands;
using Saga.Poc.Saga.Fin.App.Events;
using Saga.Poc.Saga.Fin.Domain.Entities;
using Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Infra.Bus.Rebus;
using Saga.Poc.Saga.Infra.Bus.Rebus.Notifications;
using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Rebus.Handlers;
using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.App.CommandHandlers
{
    public class BankAccountHandler : CommandHandler,
        IHandleMessages<CreateNewBankAccountCommand>,
        IHandleMessages<UpdateBankAccountBalanceCommand>
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountHandler(IBusHandler bus,
            IHandleMessages<DomainNotification> notifications,
            IUoW uow,
            IBankAccountRepository bankAccountRepository) :
            base(bus, notifications, uow)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task Handle(CreateNewBankAccountCommand message)
        {
            var bankAccount = new BankAccount(message.BankId, message.AccountNumber,
                message.CustomerName, message.InitialBalance);

            if (!bankAccount.IsValid())
            {
                var messageType = message.GetType().Name;
                foreach (var error in bankAccount.ValidationResult.Errors)
                    await NotifyError(messageType, error.ErrorMessage);
            }
            else
            {
                _bankAccountRepository.Add(bankAccount);

                await _uow.SaveChangesAsync();

                await _bus.RaiseEvent(new CreatedNewBankAccountEvent(message.AggregateId, bankAccount.Id));
            }
        }

        public async Task Handle(UpdateBankAccountBalanceCommand message)
        {
            var bankAccount = await _bankAccountRepository.GetByBankIdAndAccountNumber(message.BankId, message.AccountNumber);
            if (bankAccount == null)
            {
                await NotifyError(message.GetType().Name, "Invalid bank account");

                await _bus.RaiseEvent(new UpdateBankAccountBanlanceFailedEvent(message.AggregateId, Guid.Empty));
            }
            else
            {
                if (!bankAccount.HasEnoughBalance(message.Value))
                {
                    await NotifyError(message.GetType().Name, "There isn't enough balance for this operation");

                    await _bus.RaiseEvent(new UpdateBankAccountBanlanceFailedEvent(message.AggregateId, bankAccount.BankId));
                }
                else
                {
                    bankAccount.DecreaseBalance(message.Value);

                    _bankAccountRepository.Update(bankAccount);

                    await _uow.SaveChangesAsync();

                    await _bus.RaiseEvent(new UpdatedBankAccountBalanceEvent(message.AggregateId, bankAccount.BankId, bankAccount.Balance));
                }
            }
        }
    }
}
