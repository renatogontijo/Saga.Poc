using Saga.Poc.Saga.Core.Messages;
using System;

namespace Saga.Poc.Saga.Core.Events
{
    public class CreatedDailyExtractLotEvent : IntegrationEvent
    {
        public CreatedDailyExtractLotEvent(Guid aggregateId, Guid dailyExtractLotId)
        {
            AggregateId = aggregateId;
            DailyExtractLotId = dailyExtractLotId;
        }

        public Guid DailyExtractLotId { get; private set; }
    }
}
