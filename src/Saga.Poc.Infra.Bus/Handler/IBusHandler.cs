using Saga.Poc.Saga.Core.Messages;
using Saga.Poc.Saga.Infra.Bus.Messages;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Infra.Bus.Handler
{
    public interface IBusHandler
    {
        Task SendCommand<T>(T command) where T : Command;

        Task SendCommandSaga<T>(T command) where T : CommandSaga;

        Task SendQuery<T>(T query) where T : Query;

        Task RaiseEvent<T>(T @event) where T : Event;

        Task RaiseIntegrationEvent<T>(T @event) where T : IntegrationEvent;
    }
}
