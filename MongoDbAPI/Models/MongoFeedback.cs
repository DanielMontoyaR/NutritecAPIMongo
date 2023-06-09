using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDbAPI.Repositories;
namespace MongoDbAPI.Models
{

    
    public class MongoFeedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string client_id { get; set; } = string.Empty;
        public string nutritionist_message { get; set; } = string.Empty;
    }
}
