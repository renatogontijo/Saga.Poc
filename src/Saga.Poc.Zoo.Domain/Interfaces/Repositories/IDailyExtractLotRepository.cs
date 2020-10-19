using Saga.Poc.Saga.Core.Repositories;
using Saga.Poc.Saga.Zoo.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.Domain.Interfaces.Repositories
{
    public interface IDailyExtractLotRepository : IRepository<DailyExtractLot>, IDisposable
    {
        Task<DailyExtractLot> GetById(Guid id);

        Task<DailyExtractLot> GetDailyExtractLotByManagementCategoryId(Guid managementCategoryId);

        Task<ManagementCategory> GetManagementCategoryById(Guid managementCategoryId);

        void Add(DailyExtractLot dailyExtractLot);

        void Update(DailyExtractLot dailyExtractLot);
    }
}
