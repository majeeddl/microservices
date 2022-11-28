using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Domains.Interfaces
{
    public interface IEntity
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Timestamp)]
        public DateTime CreatedAt { get; set; }

        [BsonRepresentation(BsonType.Timestamp)]
        public DateTime UpdatedAt { get; set; }
    }
}
