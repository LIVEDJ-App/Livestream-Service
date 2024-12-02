using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livestream.Infrastructure.RabbitMQ
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event, string queueName, string channelName) where T : class;
    }
}