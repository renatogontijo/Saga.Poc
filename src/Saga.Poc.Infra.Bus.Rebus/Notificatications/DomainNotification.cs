using Saga.Poc.Saga.Infra.Bus.Rebus.Messages;

namespace Saga.Poc.Saga.Infra.Bus.Rebus.Notifications
{
    public class DomainNotification : DomainMessage
    {
        public DomainNotification(string key, string value) : 
            base(key, value)
        {
        }
    }
}
