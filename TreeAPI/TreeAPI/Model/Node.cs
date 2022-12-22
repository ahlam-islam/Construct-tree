using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TreeAPI.Model;

namespace TreeAPI.Model
{
    [BsonIgnoreExtraElements]
    public class Node
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
    
        [BsonElement("isExpanded")]
        public bool? IsExpanded { get; set; }
        [BsonElement("children")]
        public List<Children>? Children { get; set; } = null;
    }
}
