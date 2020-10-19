using Saga.Poc.Saga.Zoo.App.Requests;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.App.Interfaces
{
    public interface IDailyExtractLotService
    {
        Task CreateNewDailyExtractLot(CreateDailyExtractLotRequest request);

        Task UpdateDailyExtractLot(UpdateDailyExtractLotRequest request);
    }
}
