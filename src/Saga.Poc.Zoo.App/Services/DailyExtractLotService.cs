using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Zoo.App.Commands;
using Saga.Poc.Saga.Zoo.App.Interfaces;
using Saga.Poc.Saga.Zoo.App.Requests;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.App.Services
{
    public class DailyExtractLotService : IDailyExtractLotService
    {
        private readonly IBusHandler _bus;

        public DailyExtractLotService(IBusHandler bus)
        {
            _bus = bus;
        }

        public async Task CreateNewDailyExtractLot(CreateDailyExtractLotRequest request)
        {
            var command = new CreateNewDailyExtractLotCommand(request.Name, request.ManagementCategoryId, request.HeadsAmount);
            await _bus.SendCommand(command);
        }

        public async Task UpdateDailyExtractLot(UpdateDailyExtractLotRequest request)
        {
            var command = new UpdateDailyExtractLotCommand(request.DailyExtractLotId, request.Name, request.ManagementCategoryId);
            await _bus.SendCommand(command);
        }
    }
}
