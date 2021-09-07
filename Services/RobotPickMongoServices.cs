using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using MongoDB.Bson;
using Recycle.Models;
using Recycle.ViewModels;

namespace Recycle.Services
{
    public class RobotPickMongoServices
    {
        private readonly IMongoCollection<MongoPickDBmodel> collection1S;

        
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
        
        public RobotPickMongoServices()
        {
            var client = new MongoClient("mongodb://localhost:27017");//settings.ConnectionString);
            var database = client.GetDatabase("mongoDBrobot1");//settings.DatabaseName);
            collection1S = database.GetCollection<MongoPickDBmodel>("robot1db");//settings.DeltaRobotCollectionName);
            // var options = new CreateIndexOptions{ Unique = true};
            // collection1S.Indexes.DropOne("{Datetimetag:1}");//,options);
            // collection1S.Indexes.CreateOne("{Datetimetag:1}");//,options); 
            // database.GetCollection<MongoPickDBmodel>("robot1db").Indexes.CreateOne("{Datetimetag:-1}",options);
            Console.WriteLine("\n--------Hi---------: robotmongodbServices.cs : !!\n");//" 1:{0}, 2:{1}, 3:{2}", settings.DatabaseName, settings.ConnectionString,settings.DeltaRobotCollectionName);
        }
        
        //C-R-U-D DB
        //C:Create PET DB data
        public MongoPickDBmodel Create(MongoPickDBmodel mongodbmodel)
        {
            collection1S.InsertOne(mongodbmodel);
            return mongodbmodel;
        }
        
        //C:Create PET DB data II
        //Api1 : write db for Delta-Robot get what kind of pet bottle now
        public MongoPickDBmodel Dumpdata(string btName, string btType,  int conf,string sink,string robotID)
        {
            MongoPickDBmodel mongodbmodel = new MongoPickDBmodel
            {
                RobotID = robotID,
                BottleName= btName,
                Category = btType,
                Confidence = conf,
                Sink = sink,
                Datetimetag = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Timestamp = DateTime.Now.ToLocalTime(),
            };
            collection1S.InsertOne(mongodbmodel);
            return mongodbmodel;
        }

        //R:Read
        public List<MongoPickDBmodel> Get()
        {
            return collection1S.Find(model1 => true).ToList(); 
        }
        //R:Read I
        public MongoPickDBmodel Get(long timetag)
        {
            Console.WriteLine("\n--------: RobotMongoDbServices.cs --GET--ID==[{0}] !\n ",timetag);
            var model1 = Builders<MongoPickDBmodel>.Filter.Eq("Datetimetag", timetag);

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
        public long Get_petCurAmount_perUnitTime(int MM, int HH, string sinksort, string bottleType, string robotID="robot000001")
        {
            var timetagNow = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var timetagToday = ((DateTimeOffset)DateTime.Today).ToUnixTimeMilliseconds();
            Console.WriteLine("\n--------: RobotMongoDbServices.cs --GET--ID==[{0}] !\n ",timetagNow);
            // var model1 = Builders<MongoPickDBmodel>.Filter.Eq("Datetimetag", timetag);

            var le_Now = Builders<MongoPickDBmodel>.Filter.Lte(x=> x.Datetimetag,timetagNow);
            // 1 sec= 1000 * 1 * 1 =1000 * MM * HH
            // 1 min= 60* 1000 * 1 * 1 =60000 * MM * HH
            //60 min= 60000*60*1 =60000 * MM * HH
            //9 hr= 60000*60*9 =60000 * MM * HH
            var gt_earily8hr = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-28800000);
            var gt_earily1hr = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-3600000);
            var gt_earily1Min = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-60000);
            var gt_earilyHalfMin = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-30000);
            var sinkSort = Builders<MongoPickDBmodel>.Filter.Eq(x => x.Sink , sinksort);
            var RobotID = Builders<MongoPickDBmodel>.Filter.Eq(x => x.RobotID , robotID);
            var BottleType = Builders<MongoPickDBmodel>.Filter.Eq(x => x.BottleName , bottleType);
            var gt_todayBegin = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-timetagToday);
            // guery one kind pet how many pick counts before few how earily 
            if (sinksort != null && MM !=0 && HH > 1)
            {
                return collection1S.Find(le_Now & sinkSort & gt_todayBegin & RobotID & BottleType ).CountDocuments();
            } 
            // guery all kind pet how many pick counts before today begining
            // else if (MM !=0 && HH>1)
            // {
            //     return collection1S.Find(le_Now & gt_todayBegin& RobotID ).CountDocuments();
            // }
            // guery all kind pet how many pick counts before previous half one Min  
            else if (MM ==1 && HH==1  )
            {
                return collection1S.Find(le_Now & gt_earilyHalfMin & RobotID ).CountDocuments();
            }
            else if (MM ==2  && HH==1 )
            {
                return collection1S.Find(le_Now & gt_earily1Min & RobotID  ).CountDocuments();
            }
            else if (MM ==60  && HH==1 )
            {
                return collection1S.Find(le_Now & gt_earily1hr & RobotID  ).CountDocuments();
            }
            else if (MM ==60  && HH==8 )
            {
                return collection1S.Find(le_Now & gt_earily8hr & RobotID  ).CountDocuments();
            }
            // find newest one time pet confidence  
            // else
            // {
            //     var accupation = (long) collection1S.Find(le_Now & sinkSort & gt_todayBegin & RobotID & BottleType)
            //         .CountDocuments();
            //     var total = collection1S.Find(le_Now &  gt_todayBegin & RobotID & BottleType)
            //         .CountDocuments();
            //     if (total != null || total != 0)
            //         return  (int)(accupation / total);
            //     return 0;
            //     // return (long)collection1S.Find( le_Now & sinkSort & gt_todayBegin & RobotID  & BottleType).SortByDescending(x => x.Id).ToList()[0].Confidence;
            // }
            return 0;
            // return collection1S.Find(f1).ToCursor().FirstOrDefault();
            // var result = _collection1s.Find(model1).FirstOrDefault();
            // return _collection1s.Find(bmodel => bmodel.Datetimetag == timetag).FirstOrDefault();
            // return _collection1s.Find(model1 => model1.Id == id).FirstOrDefault();

        }
        
        
        
        public long Get_petCurAmount_perUnitTime1(long timetagNow, int MM, int HH, string sinksort, string bottleType, string robotID="robot000001")
        {
            // var timetagNow = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var timetagToday = ((DateTimeOffset)DateTime.Today).ToUnixTimeMilliseconds();
            Console.WriteLine("\n--------: RobotMongoDbServices.cs --GET--ID==[{0}] !\n ",timetagNow);
            // var model1 = Builders<MongoPickDBmodel>.Filter.Eq("Datetimetag", timetag);

            var le_Now = Builders<MongoPickDBmodel>.Filter.Lte(x=> x.Datetimetag,timetagNow);
            // 1 sec= 1000 * 1 * 1 =1000 * MM * HH
            // 1 min= 60* 1000 * 1 * 1 =60000 * MM * HH
            //60 min= 60000*60*1 =60000 * MM * HH
            //9 hr= 60000*60*9 =60000 * MM * HH
            var gt_earily8hr = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-28800000);
            var gt_earily1hr = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-3600000);
            var gt_earily1Min = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-60000);
            var gt_earilyHalfMin = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-30000);
            var sinkSort = Builders<MongoPickDBmodel>.Filter.Eq(x => x.Sink , sinksort);
            var RobotID = Builders<MongoPickDBmodel>.Filter.Eq(x => x.RobotID , robotID);
            var BottleType = Builders<MongoPickDBmodel>.Filter.Eq(x => x.BottleName , bottleType);
            var gt_todayBegin = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetagNow-timetagToday);
            // guery one kind pet how many pick counts before few how earily 
            if (sinksort != null && MM !=0 && HH > 1)
            {
                return collection1S.Find(le_Now & sinkSort & gt_todayBegin & RobotID & BottleType ).CountDocuments();
            }
            else if (MM ==1 && HH==1  )
            {
                return collection1S.Find(le_Now & gt_earilyHalfMin & RobotID ).CountDocuments();
            }
            else if (MM ==2  && HH==1 )
            {
                return collection1S.Find(le_Now & gt_earily1Min & RobotID  ).CountDocuments();
            }
            else if (MM ==60  && HH==1 )
            {
                return collection1S.Find(le_Now & gt_earily1hr & RobotID  ).CountDocuments();
            }
            else if (MM ==60  && HH==8 )
            {
                return collection1S.Find(le_Now & gt_earily8hr & RobotID  ).CountDocuments();
            }
            return 0;


        }
        
        public long GetDayTime(long timetag)
        {
            Console.WriteLine("\n--------: RobotMongoDbServices.cs --GET--ID==[{0}] !\n ",timetag);
            var model1 = Builders<MongoPickDBmodel>.Filter.Eq("Datetimetag", timetag);

            if (model1 == null)
            {
                return 0;
            }else
            {
                var f1 = Builders<MongoPickDBmodel>.Filter.Lte(x=> x.Datetimetag,timetag);
                var f2 = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetag-28800000);
                return collection1S.Find(f1 & f2 ).CountDocuments();
                // return collection1S.Find(f1).ToCursor().FirstOrDefault();
                // var result = _collection1s.Find(model1).FirstOrDefault();
                // return _collection1s.Find(bmodel => bmodel.Datetimetag == timetag).FirstOrDefault();
                // return _collection1s.Find(model1 => model1.Id == id).FirstOrDefault();
            }
        }
        
        public  decimal GetConfidence(long timetag)
        {
            Console.WriteLine("\n--------: RobotMongoDbServices.cs --GET--ID==[{0}] !\n ",timetag);
            var model1 = Builders<MongoPickDBmodel>.Filter.Eq("Datetimetag", timetag);

            if (model1 == null)
            {
                return 0;
            }else
            {
                var f1 = Builders<MongoPickDBmodel>.Filter.Lte(x=> x.Datetimetag,timetag);
                var f2 = Builders<MongoPickDBmodel>.Filter.Gt(x=> x.Datetimetag,timetag-60000);
                return collection1S.Find(f1 & f2 ).FirstOrDefault().Confidence;
                // return collection1S.Find(f1).ToCursor().FirstOrDefault();
                // var result = _collection1s.Find(model1).FirstOrDefault();
                // return _collection1s.Find(bmodel => bmodel.Datetimetag == timetag).FirstOrDefault();
                // return _collection1s.Find(model1 => model1.Id == id).FirstOrDefault();
                int id = 10000;
                // var f3 = Builders<MongoPickDBmodel>.Filter.Eq(x => x.Id,id);
                // ObjectId("507c7f9bcf89cd7884f6c0e").getTimestamp();
            }
        }
        
        //U
        public void Update(string id, MongoPickDBmodel moedl1In) =>
            collection1S.ReplaceOne(model1 => model1.Id == id, moedl1In);
        //D
        public void Remove(MongoPickDBmodel moedl1In) =>
            collection1S.DeleteOne(model1 => model1.Id == moedl1In.Id); 
        //D
        public void Remove(string id) =>
            collection1S.DeleteOne(model1 => model1.Id == id); 
    }
}