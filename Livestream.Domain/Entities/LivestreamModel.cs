using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Livestream.Domain.Entities
{
    public class LivestreamModel
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal LivestreamNumber { get; set; }
    }
}


