using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Fin.App.Events
{
    public class CreatedNewBankAccountEvent : Event
    {
        public CreatedNewBankAccountEvent(Guid aggregateId, Guid bankAccountId)
        {
            AggregateId = aggregateId;
            BankAccountId = bankAccountId;
        }

        public Guid BankAccountId { get; private set; }
    }
}
