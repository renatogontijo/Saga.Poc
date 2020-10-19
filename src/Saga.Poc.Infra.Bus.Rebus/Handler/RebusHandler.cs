using Saga.Poc.Saga.Core.Messages;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Infra.Bus.Messages;
using Rebus.Bus;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Infra.Bus.Rebus
{
    public class RebusHandler : IBusHandler
    {
        private readonly IBus _bus;

        public RebusHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task RaiseEvent<T>(T @event) where T : Event
        {
            await _bus.Publish(@event);
        }

        public async Task RaiseIntegrationEvent<T>(T @event) where T : IntegrationEvent
        {
            await _bus.Publish(@event);
        }

        public async Task SendCommand<T>(T command) where T : Command
        {
            await _bus.Send(command);
        }

        public async Task SendCommandSaga<T>(T command) where T : CommandSaga
        {
            await _bus.Send(command);
        }

        public async Task SendQuery<T>(T query) where T : Query
        {
            await _bus.Send(query);
        }
    }
}
