using Saga.Poc.Saga.Infra.Bus.Handler;

namespace Saga.Poc.Saga.Infra.Bus.Rebus
{
    public abstract class IntegrationEventHandler
    {
        protected readonly IBusHandler _bus;

        public IntegrationEventHandler(IBusHandler bus)
        {
            _bus = bus;           
        }
    }
}
