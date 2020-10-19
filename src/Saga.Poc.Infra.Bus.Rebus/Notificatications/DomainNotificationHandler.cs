using Rebus.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Infra.Bus.Rebus.Notifications
{
    public class DomainNotificationHandler : IHandleMessages<DomainNotification>
    {
        private IList<DomainNotification> _notifications;

        public DomainNotificationHandler() => _notifications = new List<DomainNotification>();

        public async Task Handle(DomainNotification notification)
        {
            _notifications.Add(notification);

            await Task.CompletedTask;
        }

        public virtual IList<DomainNotification> GetNotifications() => _notifications;

        public void Clear() => _notifications.Clear();

        public void Dispose() => _notifications.Clear();
    }
}
