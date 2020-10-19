using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Zoo.App.Commands
{
    public class CreateNewDailyExtractLotCommand : Command
    {
        protected CreateNewDailyExtractLotCommand()
        {
        }

        public CreateNewDailyExtractLotCommand(Guid aggregateId, string name, Guid manamementCategoryId, int headsAmount)
        {
            AggregateId = aggregateId;
            Name = name;
            ManamementCategoryId = manamementCategoryId;
            HeadsAmount = headsAmount;
        }

        public CreateNewDailyExtractLotCommand(string name, Guid manamementCategoryId, int headsAmount)
        {
            AggregateId = Guid.NewGuid();
            Name = name;
            ManamementCategoryId = manamementCategoryId;
            HeadsAmount = headsAmount;
        }

        public string Name { get; private set; }

        public Guid ManamementCategoryId { get; private set; }

        public int HeadsAmount { get; private set; }
    }
}
