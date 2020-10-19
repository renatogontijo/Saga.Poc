using System;

namespace Saga.Poc.Saga.Infra.Bus.Messages
{
    public abstract class Message
    {
        public Guid AggregateId { get; set; }
        
        public DateTime Timestamp { get; private set; }

        protected Message()
        {
            Timestamp = DateTime.Now;
        }
    }
}
