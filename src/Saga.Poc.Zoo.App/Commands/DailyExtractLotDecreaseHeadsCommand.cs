using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Zoo.App.Commands
{
    public class DailyExtractLotDecreaseHeadsCommand : Command
    {
        protected DailyExtractLotDecreaseHeadsCommand()
        {
        }

        public DailyExtractLotDecreaseHeadsCommand(Guid dailyExtractLotId, int headsToDecrease)
        {
            AggregateId = dailyExtractLotId;
            DailyExtractLotId = dailyExtractLotId;
            HeadsToDecrease = headsToDecrease;
        }

        public Guid DailyExtractLotId { get; private set; }

        public int HeadsToDecrease { get; private set; }
    }
}
