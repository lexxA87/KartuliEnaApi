using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KartuliEnaApi.Models
{
    public class Word
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Ka { get; set; } = null!;
        public string Ru { get; set; } = null!;
        public string En { get; set; } = null!;
        public string[] Examples { get; set; }
        public List<Tag> Tags { get; set; }
        public string Role { get; set; } = null!;
    }
}
