using Saga.Poc.Saga.Fin.App.Commands;
using Saga.Poc.Saga.Fin.App.Commands.Saga;
using Saga.Poc.Saga.Fin.App.Interfaces;
using Saga.Poc.Saga.Fin.App.Requests;
using Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Infra.Bus.Handler;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.App.Services
{
    public class BuyCattleService : IBuyCattleService
    {
        private readonly IBusHandler _bus;

        public BuyCattleService(IBusHandler bus)
        {
            _bus = bus;
        }

        public async Task BuyCattleRegisterNew(BuyCattleRegisterNewRequest request)
        {
            var command = new BuyRegisterSagaCommand(request.SupplierName, request.BuyDate, request.BuyValue,
                request.BankId, request.AccountNumber, request.ManagementCategoryId, request.PurchasedHeads);
            
            await _bus.SendCommandSaga(command);
        }
    }
}
