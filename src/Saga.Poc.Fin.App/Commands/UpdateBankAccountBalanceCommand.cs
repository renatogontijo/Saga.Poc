using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Fin.App.Commands
{
    public class UpdateBankAccountBalanceCommand : Command
    {
        protected UpdateBankAccountBalanceCommand()
        {
        }

        public UpdateBankAccountBalanceCommand(Guid aggregateId, Guid bankId, string accountNumber,
            decimal value)
        {
            AggregateId = aggregateId;
            BankId = bankId;
            AccountNumber = accountNumber;
            Value = value;
        }

        public Guid BankId { get; private set; }

        public string AccountNumber { get; private set; }

        public decimal Value { get; private set; }
    }
}
