using Saga.Poc.Saga.Core.Messages;
using System;

namespace Saga.Poc.Saga.Core.Events
{
    public class UpdatedDailyExtractLotEvent : IntegrationEvent
    {
        public UpdatedDailyExtractLotEvent(Guid aggregateId, Guid dailyExtractLotId, Guid managementCategoryId, int headsAmount)
        {
            AggregateId = aggregateId;
            DailyExtractLotId = dailyExtractLotId;
            ManagementCategoryId = managementCategoryId;
            HeadsAmount = headsAmount;
        }

        public Guid DailyExtractLotId { get; private set; }

        public Guid ManagementCategoryId { get; private set; }

        public long HeadsAmount { get; private set; }
    }
}
