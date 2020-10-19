using System;

namespace Saga.Poc.Saga.Core.Messages
{
    public abstract class MessageBase
    {
        public Guid AggregateId { get; set; }

        public DateTime Timestamp { get; private set; }

        protected MessageBase()
        {
            Timestamp = DateTime.Now;
        }
    }
}
