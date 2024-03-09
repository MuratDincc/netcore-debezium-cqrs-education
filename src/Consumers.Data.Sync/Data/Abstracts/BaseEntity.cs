using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consumers.Data.Sync.Data.Abstracts;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}