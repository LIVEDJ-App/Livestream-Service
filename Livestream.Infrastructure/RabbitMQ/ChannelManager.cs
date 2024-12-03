using RabbitMQ.Client;

namespace Livestream.Infrastructure.RabbitMQ
{
    public class ChannelManager
    {
        private readonly IConnection _connection;
        private IModel _channel;

        public ChannelManager()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
        }

        public IModel GetOrCreateChannel(string channelName)
        {
            if (_channel == null || _channel.IsClosed)
            {
                _channel = _connection.CreateModel();
                Console.WriteLine($"Channel '{channelName}' created or reused.");
            }
            return _channel;
        }
    }
}
