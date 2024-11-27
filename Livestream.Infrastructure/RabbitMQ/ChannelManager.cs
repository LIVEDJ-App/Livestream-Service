using RabbitMQ.Client;

namespace Livestream.Infrastructure.RabbitMQ
{
    public class ChannelManager
    {
        private readonly IConnection _connection;

        public ChannelManager()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
        }

        public IModel CreateChannel(string channelName)
        {
            var channel = _connection.CreateModel();
            Console.WriteLine($"Channel '{channelName}' created.");
            return channel;
        }
    }
}
