
using Livestream.Domain.Entities;

namespace Livestream.Persistence.Mongo.Interfaces
{
    public interface ILivestreamRepository
    {
        Task AddAsync(LivestreamModel livestream);
    }
}

