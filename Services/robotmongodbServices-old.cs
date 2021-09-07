using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OData.Edm;
using Recycle.Models;

namespace Recycle.Services
{
    public class robotmongodbServices
    {
        private readonly IMongoCollection<MongoDBmodel> collection1S;

        
        //BottleType == Btype
        public enum Btype
        {
            P = 0,
            COLOR = 1,
            SOY=2,
            OIL=3,
            TRAY=4,
            CH=5,
            OTHER=6,
        }
		
        //BottleKind == Bkind
        public enum Bkind
        {
            PET = 0,
            PP = 1,
            PS=2,
            PLA=3,
            PC=4,
            PVC=5,
        }
        
        public robotmongodbServices()
        {
            var client = new MongoClient("mongodb://localhost:27017");//settings.ConnectionString);
            var database = client.GetDatabase("mongoDBrobot1");//settings.DatabaseName);
            collection1S = database.GetCollection<MongoDBmodel>("robot1db");//settings.DeltaRobotCollectionName);
            Console.WriteLine("\n--------Hi---------: robotmongodbServices.cs : !!\n");//" 1:{0}, 2:{1}, 3:{2}", settings.DatabaseName, settings.ConnectionString,settings.DeltaRobotCollectionName);
        }
        
        //C-R-U-D DB
        //C:Create PET DB data
        public MongoDBmodel Create(MongoDBmodel mongodbmodel)
        {
            collection1S.InsertOne(mongodbmodel);
            return mongodbmodel;
        }
        
        //C:Create PET DB data II
        public MongoDBmodel Dumpdata(string btName, int conf,string btType=nameof(Bkind.PET))
        {
            MongoDBmodel mongodbmodel = new MongoDBmodel
            {
                BottleName = btName,
                Category = btType,
                Confidence = conf,
                Datetimetag = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Timestamp = DateTime.Now.ToLocalTime(),
            };
            collection1S.InsertOne(mongodbmodel);
            return mongodbmodel;
        }

        //R:Read
        public List<MongoDBmodel> Get()
        {
            return collection1S.Find(model1 => true).ToList(); 
        }
        //R:Read I
        public MongoDBmodel Get(long timetag)
        {
            Console.WriteLine("\n--------Hello---------: mongoDBmodel.cs :mongodbmodel --GET !!\n");
            var model1 = Builders<MongoDBmodel>.Filter.Eq("Datetimetag", timetag);

            if (model1 == null)
            {
                return null;
            }else
            {
                return collection1S.Find(x => x.Datetimetag > (timetag-1000) ).FirstOrDefault();            
                // var result = _collection1s.Find(model1).FirstOrDefault();
                // return _collection1s.Find(bmodel => bmodel.Datetimetag == timetag).FirstOrDefault();
                // return _collection1s.Find(model1 => model1.Id == id).FirstOrDefault();
            }
        }
        //U
        public void Update(string id, MongoDBmodel moedl1In) =>
            collection1S.ReplaceOne(model1 => model1.Id == id, moedl1In);
        //D
        public void Remove(MongoDBmodel moedl1In) =>
            collection1S.DeleteOne(model1 => model1.Id == moedl1In.Id); 
        //D
        public void Remove(string id) =>
            collection1S.DeleteOne(model1 => model1.Id == id); 
    }
}