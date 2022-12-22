using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TreeAPI.Model
{
    [BsonIgnoreExtraElements]
    public class Children
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("isExpanded")]
        public bool? IsExpanded { get; set; }

        [BsonElement("children")]
        public Children[]? Childrens { get; set; }
    

    }
}
