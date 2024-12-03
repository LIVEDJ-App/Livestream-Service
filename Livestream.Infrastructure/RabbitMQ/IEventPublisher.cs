namespace Livestream.Infrastructure.RabbitMQ
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event, string queueName, string channelName) where T : class;
    }
}