using Livestream.Infrastructure.RabbitMQ;
using MediatR;

namespace Livestream.Application.Events
{
    public class LivestreamCreatedEventHandler : INotificationHandler<LivestreamCreatedEvent>
    {
        private readonly EventPublisher _eventPublisher;

        public LivestreamCreatedEventHandler(EventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task Handle(LivestreamCreatedEvent notification, CancellationToken cancellationToken)
        {
            _eventPublisher.Publish(notification, "LivestreamCreatedQueue", "LivestreamChannel");
            Console.WriteLine($"Published LivestreamCreatedEvent for {notification.LivestreamId}");
            await Task.CompletedTask;
        }
    }

}
