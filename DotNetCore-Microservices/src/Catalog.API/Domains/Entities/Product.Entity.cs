

using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Domains.Entities
{
    public class Product : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }


    }

}
