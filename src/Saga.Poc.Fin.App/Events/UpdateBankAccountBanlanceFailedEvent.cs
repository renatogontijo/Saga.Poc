using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Core.Events
{
    public class UpdateBankAccountBanlanceFailedEvent : Event
    {
        public UpdateBankAccountBanlanceFailedEvent(Guid aggregateId, Guid bankAccountId)
        {
            AggregateId = aggregateId;
            BankAccountId = bankAccountId;
        }

        public Guid BankAccountId { get; private set; }
    }
}
