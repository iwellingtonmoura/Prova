using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Prova.Data.Models;

//public interface IDocument
//{
//	[BsonId]
//	[BsonRepresentation(BsonType.String)]

//	ObjectId Id { get; set; }
//	DateTime CreatedAt { get; }
//}

//public abstract class Document : IDocument
//{
//	public ObjectId Id { get; set; }
//	public DateTime CreatedAt => Id.CreationTime;
//}

public abstract class Document : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private ObjectId _Id;


    [BsonIgnore]
    public virtual ObjectId Id
    {
        get
        {
            return _Id;
        }
        set
        {
            _Id = value;
        }
    }

    public DateTime CreatedAt => Id.CreationTime;
}