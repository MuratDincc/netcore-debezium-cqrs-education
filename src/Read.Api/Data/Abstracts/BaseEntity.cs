using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.Api.Data.Abstracts;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}