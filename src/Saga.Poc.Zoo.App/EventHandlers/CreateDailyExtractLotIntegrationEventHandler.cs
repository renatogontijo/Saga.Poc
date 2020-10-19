using Saga.Poc.Saga.Core.Events;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Infra.Bus.Rebus;
using Saga.Poc.Saga.Zoo.App.Commands;
using Rebus.Handlers;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.App.EventHandlers
{
    public class CreateDailyExtractLotIntegrationEventHandler : IntegrationEventHandler,
        IHandleMessages<CreateDailyExtractLotEvent>
    {
        public CreateDailyExtractLotIntegrationEventHandler(IBusHandler bus) : 
            base(bus)
        {
        }

        public async Task Handle(CreateDailyExtractLotEvent message)
        {
            var lotName = $"Compra de {message.PurchasedHeads} cabeça(s)";
            var cmdCreateDailyExtractLot = new CreateNewDailyExtractLotCommand(message.AggregateId, lotName, message.ManagementCategoryId, message.PurchasedHeads);
            await _bus.SendCommand(cmdCreateDailyExtractLot);            
        }
    }
}
