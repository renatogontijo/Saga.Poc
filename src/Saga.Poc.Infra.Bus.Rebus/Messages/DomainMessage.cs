using Saga.Poc.Saga.Infra.Bus.Messages;
using System;

namespace Saga.Poc.Saga.Infra.Bus.Rebus.Messages
{
    public class DomainMessage : Command
    {
        public DomainMessage(string key, string value)
        {
            DomainMessageId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }

        public Guid DomainMessageId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public int Version { get; private set; }
    }
}
