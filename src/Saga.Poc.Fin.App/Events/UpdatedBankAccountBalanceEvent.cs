using Saga.Poc.Saga.Core.Messages;
using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Core.Events
{
    public class UpdatedBankAccountBalanceEvent : Event
    {
        public UpdatedBankAccountBalanceEvent(Guid aggregateId, Guid bankAccountId, decimal balance)
        {
            AggregateId = aggregateId;
            BankAccountId = bankAccountId;
            Balance = balance;
        }

        public Guid BankAccountId { get; private set; }

        public decimal Balance { get; private set; }
    }
}
