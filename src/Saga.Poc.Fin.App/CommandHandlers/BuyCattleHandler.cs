using Saga.Poc.Saga.Core.Events;
using Saga.Poc.Saga.Fin.App.Commands;
using Saga.Poc.Saga.Fin.Domain.Entities;
using Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Infra.Bus.Rebus;
using Saga.Poc.Saga.Infra.Bus.Rebus.Notifications;
using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Rebus.Handlers;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.App.CommandHandlers
{
    public class BuyCattleHandler : CommandHandler,
        IHandleMessages<BuyRegisterNewCommand>
    {
        private readonly IBuyCattleRepository _buyCattleRepository;

        public BuyCattleHandler(IBusHandler bus,
            IHandleMessages<DomainNotification> notifications,
            IUoW uow,
            IBuyCattleRepository buyCattleRepository) :
            base(bus, notifications, uow)
        {
            _buyCattleRepository = buyCattleRepository;
        }

        public async Task Handle(BuyRegisterNewCommand message)
        {
            var buyCattle = new BuyCattle(message.BuyDate, message.SupplierName, message.BuyValue);
            if (!buyCattle.IsValid())
            {
                foreach (var error in buyCattle.ValidationResult.Errors)
                    await NotifyError(message.GetType().Name, error.ErrorMessage);

                await _bus.RaiseEvent(new BuyFailedEvent(message.AggregateId, buyCattle.Id, buyCattle.SupplierName,
                    buyCattle.BuyDate, buyCattle.BuyValue, message.BankId, message.AccountNumber,
                    message.ManagementCategoryId, message.PurchasedHeads));
            }
            else
            {
                _buyCattleRepository.Add(buyCattle);

                await _uow.SaveChangesAsync();

                await _bus.RaiseEvent(new BuyRegisteredEvent(message.AggregateId, buyCattle.Id, buyCattle.SupplierName,
                    buyCattle.BuyDate, buyCattle.BuyValue, message.BankId, message.AccountNumber,
                    message.ManagementCategoryId, message.PurchasedHeads));
            }
        }
    }
}
