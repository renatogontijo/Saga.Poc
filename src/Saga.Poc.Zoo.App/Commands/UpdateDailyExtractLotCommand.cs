using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Zoo.App.Commands
{
    public class UpdateDailyExtractLotCommand : Command
    {
        protected UpdateDailyExtractLotCommand()
        {
        }

        public UpdateDailyExtractLotCommand(Guid aggregateId, Guid dailyExtractLotId, string name, Guid manamementCategoryId)
        {
            AggregateId = aggregateId;
            DailyExtractLotId = dailyExtractLotId;
            Name = name;
            ManamementCategoryId = manamementCategoryId;
        }

        public UpdateDailyExtractLotCommand(Guid dailyExtractLotId, string name, Guid manamementCategoryId)
        {
            AggregateId = dailyExtractLotId;
            DailyExtractLotId = dailyExtractLotId;
            Name = name;
            ManamementCategoryId = manamementCategoryId;
        }

        public Guid DailyExtractLotId { get; private set; }

        public string Name { get; private set; }

        public Guid ManamementCategoryId { get; private set; }
    }
}
