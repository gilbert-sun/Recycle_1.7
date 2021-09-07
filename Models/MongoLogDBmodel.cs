using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recycle.Models
{
    public class MongoLogDBmodel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("RobotID")]
        public string RobotID;
        
        [BsonElement("Content")]
        [JsonProperty("Content")]
        public string Content { get; set; }
        
        [BsonElement("Category")]
        public string Category { get; set; }
        
        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Datetimetag")]
        public long Datetimetag { get; set; }
        
        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}