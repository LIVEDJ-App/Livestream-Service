using Livestream.Application.Events;
using Livestream.Application.Logic.Commands;
using Livestream.Domain.Entities;
using Livestream.Infrastructure.RabbitMQ;
using Livestream.Persistence.Mongo.Interfaces;
using MediatR;
using NSubstitute;

namespace Livestream.Application.Test.Livestreams
{
    public class CreateLivestreamCommandTests
    {
        [Fact]
        public async Task Handle_ShouldAddLivestreamAndPublishEvent()
        {
            // Arrange
            var repository = Substitute.For<ILivestreamRepository>();
            var publisher = Substitute.For<IPublisher>();
            var commandHandler = new CreateLivestreamCommandHandler(repository, publisher);
            var command = new CreateLivestreamCommand("Test Stream", 123);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(command.Name, result.Name);
            Assert.Equal(command.LivestreamNumber, result.LivestreamNumber);
            await repository.Received(1).AddAsync(Arg.Is<LivestreamModel>(l => 
                l.Name == command.Name && l.LivestreamNumber == command.LivestreamNumber));
            
            await publisher.Received(1).Publish(Arg.Is<LivestreamCreatedEvent>(e => 
                e.Name == command.Name && e.LivestreamNumber == command.LivestreamNumber), CancellationToken.None);
        }
        
        [Fact]
        public async Task Handle_ShouldPublishEventToQueue()
        {
            // Arrange
            var eventPublisher = Substitute.For<IEventPublisher>();
            var eventHandler = new LivestreamCreatedEventHandler(eventPublisher);
            var livestreamEvent = new LivestreamCreatedEvent
            {
                LivestreamId = Guid.NewGuid(),
                Name = "Test Stream",
                LivestreamNumber = 123
            };

            // Act
            await eventHandler.Handle(livestreamEvent, CancellationToken.None);
            
            // Assert
            eventPublisher.Received(1).Publish(
                livestreamEvent,
                "LivestreamCreatedQueue",
                "LivestreamChannel");
        }
    }
}