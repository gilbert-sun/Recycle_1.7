using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Recycle.Models
{
    public class MongoPickDBmodel
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("RobotID")]
        public string RobotID;

        [BsonElement("BottleName")]
        [JsonProperty("BottleName")]
        public string BottleName { get; set; }
        
        [BsonElement("Confidence")]
        public decimal Confidence { get; set; }
        
        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Sink")]
        public string Sink { get; set; }

        [BsonElement("Datetimetag")]
        public long Datetimetag { get; set; }
        
        [BsonElement("Timestamp")]
        public DateTime Timestamp { get; set; }
        
    }
}