﻿using Catalog.API.Domains.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Domains.Entities
{
    public class BaseEntity : IEntity

    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Timestamp)]
        public DateTime CreatedAt { get; set; }

        [BsonRepresentation(BsonType.Timestamp)]
        public DateTime UpdatedAt { get; set; }
    }
}