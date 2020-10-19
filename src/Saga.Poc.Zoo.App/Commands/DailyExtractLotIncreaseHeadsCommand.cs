using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Zoo.App.Commands
{
    public class DailyExtractLotIncreaseHeadsCommand : Command
    {
        protected DailyExtractLotIncreaseHeadsCommand()
        {
        }

        public DailyExtractLotIncreaseHeadsCommand(Guid dailyExtractLotId, int headsToIncrease)
        {
            AggregateId = dailyExtractLotId;
            DailyExtractLotId = dailyExtractLotId;
            HeadsToIncrease = headsToIncrease;
        }

        public Guid DailyExtractLotId { get; private set; }

        public int HeadsToIncrease { get; private set; }
    }
}
