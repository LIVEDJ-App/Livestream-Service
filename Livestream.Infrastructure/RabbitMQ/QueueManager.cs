using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livestream.Infrastructure.RabbitMQ
{
    internal class QueueManager
    {
        private readonly ChannelManager _channelManager;

        public QueueManager(ChannelManager channelManager)
        {
            _channelManager = channelManager;
        }

        public void SetUpProductChannel()
        {
            var channel = _channelManager.CreateChannel("ProductChannel");
            channel.QueueDeclare("ProductCreatedQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}
