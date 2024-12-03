using Livestream.Application.Events;
using Livestream.Domain.Entities;
using Livestream.Persistence.Mongo.Interfaces;
using MediatR;

namespace Livestream.Application.Logic.Commands
{
    public class CreateLivestreamCommandHandler : IRequestHandler<CreateLivestreamCommand, LivestreamModel>
    {
        private readonly ILivestreamRepository _repository;
        private readonly IPublisher _publisher;

        public CreateLivestreamCommandHandler(ILivestreamRepository repository, IPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public async Task<LivestreamModel> Handle(CreateLivestreamCommand command, CancellationToken cancellationToken)
        {
            var livestream = new LivestreamModel
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                LivestreamNumber = command.LivestreamNumber
            };
            await _repository.AddAsync(livestream);

            var livestreamCreatedEvent = new LivestreamCreatedEvent
            {
                LivestreamId = livestream.Id,
                Name = livestream.Name,
                LivestreamNumber = livestream.LivestreamNumber
            };
            await _publisher.Publish(livestreamCreatedEvent, cancellationToken);

            return livestream;
        }

    }

}
