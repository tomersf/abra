using api.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace api.Models
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("created_at")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement("type")]

        public PetType Type { get; set; } = PetType.Other;

        [BsonElement("color")]
        public string Color { get; set; } = "white";

        [BsonElement("age")]
        public int Age { get; set; } = 0;
    }

}