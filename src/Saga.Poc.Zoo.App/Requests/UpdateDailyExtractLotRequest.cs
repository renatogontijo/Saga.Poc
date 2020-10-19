using System;

namespace Saga.Poc.Saga.Zoo.App.Requests
{
    public class UpdateDailyExtractLotRequest
    {
        public Guid DailyExtractLotId { get; set; }

        public string Name { get; set; }

        public Guid ManagementCategoryId { get; set; }
    }
}
