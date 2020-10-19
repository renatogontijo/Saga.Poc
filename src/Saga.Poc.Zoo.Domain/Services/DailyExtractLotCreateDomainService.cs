using Saga.Poc.Saga.Zoo.Domain.Entities;
using Saga.Poc.Saga.Zoo.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Zoo.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.Domain.Services
{
    public class DailyExtractLotCreateDomainService : IDailyExtractLotCreateDomainService
    {
        private readonly IDailyExtractLotRepository _dailyExtractLotRepository;

        public DailyExtractLotCreateDomainService(IDailyExtractLotRepository dailyExtractLotRepository)
        {
            _dailyExtractLotRepository = dailyExtractLotRepository;
        }

        public async Task<(DailyExtractLot, bool)> CreateNewDailyExtractLot(string name, Guid managementCategoryId, int headsAmount)
        {
            var isNewDailyExtractLot = false;

            DailyExtractLot dailyExtractLot = null;

            dailyExtractLot = await _dailyExtractLotRepository.GetDailyExtractLotByManagementCategoryId(managementCategoryId);
            if (dailyExtractLot != null)
            {
                dailyExtractLot.IncreateHeadsAmount(headsAmount);
                _dailyExtractLotRepository.Update(dailyExtractLot);
            }
            else
            {
                dailyExtractLot = new DailyExtractLot(name, managementCategoryId, headsAmount);
                _dailyExtractLotRepository.Add(dailyExtractLot);
                isNewDailyExtractLot = true;
            }

            return (dailyExtractLot, isNewDailyExtractLot);
        }
    }
}
