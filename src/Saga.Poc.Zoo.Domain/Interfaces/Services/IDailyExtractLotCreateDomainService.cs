using Saga.Poc.Domain.Core.DomainObjects;
using Saga.Poc.Saga.Zoo.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.Domain.Interfaces.Services
{
    public interface IDailyExtractLotCreateDomainService : IDomainService
    {
        Task<(DailyExtractLot, bool)> CreateNewDailyExtractLot(string name, Guid managementCategoryId, int headsAmount);
    }
}
