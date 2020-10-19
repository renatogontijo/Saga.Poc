using Saga.Poc.Saga.Zoo.Domain.Entities;
using Saga.Poc.Saga.Zoo.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Zoo.Repo.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.Repo.Repositories
{
    public class DailyExtractLotRepository : IDailyExtractLotRepository
    {
        private readonly AgroHUBZooContext Db;

        private readonly DbSet<DailyExtractLot> DbSet;

        private readonly DbSet<ManagementCategory> DbSetManagementCategory;

        public DailyExtractLotRepository(AgroHUBZooContext db)
        {
            Db = db;
            DbSet = Db.Set<DailyExtractLot>();
            DbSetManagementCategory = Db.Set<ManagementCategory>();
        }

        public async Task<DailyExtractLot> GetById(Guid id)
        {
            return await DbSet
                .Include(i => i.ManagementCategory)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<DailyExtractLot> GetDailyExtractLotByManagementCategoryId(Guid managementCategoryId)
        {
            return await DbSet
                .Include(i => i.ManagementCategory)
                .FirstOrDefaultAsync(i => i.ManagementCategoryId == managementCategoryId);
        }

        public async Task<ManagementCategory> GetManagementCategoryById(Guid managementCategoryId)
        {
            return await DbSetManagementCategory
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == managementCategoryId);
        }

        public void Add(DailyExtractLot dailyExtractLot)
        {
            DbSet.Add(dailyExtractLot);
        }

        public void Update(DailyExtractLot dailyExtractLot)
        {
            DbSet.Update(dailyExtractLot);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
