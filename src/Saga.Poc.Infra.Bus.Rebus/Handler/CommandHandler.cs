using System.Threading.Tasks;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Infra.Bus.Rebus.Notifications;
using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Rebus.Handlers;

namespace Saga.Poc.Saga.Infra.Bus.Rebus
{
    public abstract class CommandHandler
    {
        protected readonly DomainNotificationHandler _notifications;
        protected readonly IBusHandler _bus;
        protected readonly IUoW _uow;

        protected CommandHandler(IBusHandler bus,
            IHandleMessages<DomainNotification> notifications,
            IUoW uow)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
            _uow = uow;
        }

        protected async Task NotifyError(string code, string message)
        {
            await _bus.SendCommand(new DomainNotification(code, message));
        }
    }
}
