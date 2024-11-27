using Livestream.Domain.Entities;
using MediatR;

namespace Livestream.Application.Logic.Commands
{
    public class CreateLivestreamCommand : IRequest<LivestreamModel>
    {
        public string Name { get; set; }
        public decimal LivestreamNumber { get; set; }

        public CreateLivestreamCommand(string name, decimal livestreamNumber)
        {
            Name = name;
            LivestreamNumber = livestreamNumber;
        }
    }
}
