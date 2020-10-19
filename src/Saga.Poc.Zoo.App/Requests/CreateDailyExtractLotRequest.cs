using System;

namespace Saga.Poc.Saga.Zoo.App.Requests
{
    public class CreateDailyExtractLotRequest
    {
        public string Name { get; set; }

        public Guid ManagementCategoryId { get; set; }

        public int HeadsAmount { get; set; }
    }
}
