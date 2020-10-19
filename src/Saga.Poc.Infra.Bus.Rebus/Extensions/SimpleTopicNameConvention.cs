using System;
using Rebus.Extensions;
using Rebus.Topic;

namespace Saga.Poc.Saga.Infra.Bus.Rebus.Extensions
{
    internal class SimpleTopicNameConvention : ITopicNameConvention
    {
        public string GetTopic(Type eventType)
        {
            return eventType.Name;
        }
    }
}
