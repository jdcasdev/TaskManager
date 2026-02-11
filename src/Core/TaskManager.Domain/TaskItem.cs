using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskManager.Domain
{
    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = default!;

        [BsonElement("title")]
        public required string Title { get; set; }

        [BsonElement("description")]
        public required string Description { get; set; }

        [BsonElement("status")]
        public required string Status { get; set; }

        [BsonElement("eventDateTime")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EventDateTime { get; set; }
    }
}
