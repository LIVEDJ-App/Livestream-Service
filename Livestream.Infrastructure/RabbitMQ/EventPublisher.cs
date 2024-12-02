using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Livestream.Infrastructure.RabbitMQ
{
    public class EventPublisher : IEventPublisher
    {
        private readonly ChannelManager _channelManager;

        public EventPublisher(ChannelManager channelManager)
        {
            _channelManager = channelManager;
        }

        public void Publish<T>(T @event, string queueName, string channelName) where T : class
        {
            var channel = _channelManager.GetOrCreateChannel(channelName);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            Console.WriteLine($"Message published to {queueName} on {channelName}");
        }
    }
}
