
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
            var channel = _channelManager.GetOrCreateChannel("LivestreamChannel");
            channel.QueueDeclare("LivestreamCreatedQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}
