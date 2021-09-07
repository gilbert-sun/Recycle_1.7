using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using Newtonsoft.Json.Converters;
using Recycle.Models;

namespace Recycle.Services
{
    public class RobotLogMongoServices
    {
        private readonly IMongoCollection<MongoLogDBmodel> collection2S;

        //LogErrKind == LEkind
        public enum LEkind
        {
            RobotArm = 0,
            VisionSys = 1,
            ConveySys=2,
            ControSys=3,
        }
        
        public RobotLogMongoServices()
        {
            var client = new MongoClient("mongodb://localhost:27017");//settings.ConnectionString);
            var database = client.GetDatabase("mongoDBrobot4");//settings.DatabaseName);mongoDBrobot1

            collection2S = database.GetCollection<MongoLogDBmodel>("robot1logdb4");//settings.DeltaRobotCollectionName); robot1logdb
            Console.WriteLine("\n--------Hi---------: DeltaRobotLogModelServices-Log-DbServices.cs : !!\n");//" 1:{0}, 2:{1}, 3:{2}", settings.DatabaseName, settings.ConnectionString,settings.DeltaRobotCollectionName);
        }
        
        //C-R-U-D DB
        //C:Create PET DB data
        public MongoLogDBmodel Create(MongoLogDBmodel mongoMongoLogDBmodel)
        {
            collection2S.InsertOne(mongoMongoLogDBmodel);
            return mongoMongoLogDBmodel;
        }
        
        //C:Create Err LOG DB data
        public MongoLogDBmodel Dumplog(string content, string status,string btType,string robotID)
        {
            MongoLogDBmodel mongoMongoLogDBmodel = new MongoLogDBmodel
            {
                RobotID = robotID,
                Content = content,
                Category = btType, 
                Status = status,
                Datetimetag = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Timestamp = DateTime.Now.ToLocalTime(),
            };
            collection2S.InsertOne(mongoMongoLogDBmodel);
            return mongoMongoLogDBmodel;
        }  
        //C:Create PET DB data II APi
        //API2 for write db for encounting what kind of error(//RobotArm = 0,VisionSys = 1,ConveySys=2,ControSys=3,) 
        public MongoLogDBmodel Dumpdata(string content, string status,string btType,string robotID)
        {
            MongoLogDBmodel mongodbmodel = new MongoLogDBmodel
            {
                RobotID = robotID,
                Content = content,
                Category = btType,
                Status = status,
                Datetimetag = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Timestamp = DateTime.Now.ToLocalTime(),
            };
            collection2S.InsertOne(mongodbmodel);
            return mongodbmodel;
        }
        //R:Read
        public List<MongoLogDBmodel> Get()
        {
            return collection2S.Find( model1=> true).ToList(); 
        }

        
        public List<MongoLogDBmodel> GetFinalErrLog(string ErrKind =null ,string robotID="robot000001")
        {
            var todayTimeTag=((DateTimeOffset) DateTime.Today).ToUnixTimeMilliseconds();
            var RobotID = Builders<MongoLogDBmodel>.Filter.Eq(x => x.RobotID , robotID);
            var ErrSort = Builders<MongoLogDBmodel>.Filter.Eq(x => x.Category , ErrKind);
            var timetag = Builders<MongoLogDBmodel>.Filter.Gt(field: x => x.Datetimetag , 0); //todayTimeTag);
            var currErrlog = new List<MongoLogDBmodel>();
            if (ErrKind == null) 
               currErrlog = collection2S.Find(timetag & RobotID).SortByDescending(x => x.Id).Limit(10).ToList();
            else  
               currErrlog = collection2S.Find(timetag & ErrSort & RobotID).SortByDescending(x => x.Id).Limit(10).ToList();
            
            if (currErrlog.Count > 0)
                return currErrlog;
            return null;
        }
                
        public long GetCamStartTime()
        {
            var todayTimeTag=((DateTimeOffset) DateTime.Today.ToLocalTime()).ToUnixTimeMilliseconds();
            // var sortDefinition = new SortDefinitionBuilder<MongoLogDBmodel>().Ascending("Id");
            var startTimetag = collection2S.Find(x=>x.Datetimetag > todayTimeTag).First();
            // var startTimetag1 = collection2S.Find(x=>x.Datetimetag > todayTimeTag).FirstOrDefault();
            //
            // Console.WriteLine("\n--------: Robot_LogModelServices.cs ::--GetCamDurationTime {0} : {1} !!\n",startTimetag[0].Datetimetag,startTimetag1.Datetimetag  );
            //
            // // if (startTimetag[0].Datetimetag > todayTimeTag)
            // //     return startTimetag[0].Datetimetag/1000;  
            if (startTimetag.Datetimetag > todayTimeTag)
                return startTimetag.Datetimetag/1000;
            else
                return 0; //todayTimeTag/1000;
        }
        
        public long GetCamDurationTime()
        {
            var todayTimeTag=((DateTimeOffset) DateTime.Today).ToUnixTimeMilliseconds();
            var timetag = collection2S.Find(x => x.Datetimetag > todayTimeTag);
            var startTimetag = timetag.Limit(1).First();
            var currTimetag = timetag.SortByDescending(x => x.Id).Limit(1).First();
            // var sortDefinition = new SortDefinitionBuilder<MongoLogDBmodel>().Descending("Id");
            // var currTimetag=collection2S.Find(x => x.Datetimetag > todayTimeTag).Sort(sortDefinition).Limit(1);
            // currTimetag.ToCursor().First().Datetimetag;
            var durationTime = currTimetag.Datetimetag - startTimetag.Datetimetag;
            // var durationTime = 0; 
            // if (currTimetag != null)
            // var currTimetag = ((DateTimeOffset) DateTime.Now).ToUnixTimeMilliseconds();
            // var durationTime = currTimetag - startTimetag[0].Datetimetag;
            // var model1 = Builders<MongoLogDBmodel>.Filter.Gt(x=>x.Datetimetag,todayTimeTag );
            // // var durationTime = collection2S.Find(model1).SortByDescending(x => x.Id).ToList();
            if (durationTime > 0)
                return durationTime/1000;
            return 0;
        }
      
        public string GetControllerSatus()
        {
            var todayTimeTag=((DateTimeOffset) DateTime.Today).ToUnixTimeSeconds();
            var logSort = Builders<MongoLogDBmodel>.Filter.Eq(x => x.Category , nameof(LEkind.ControSys) );
            var nowCamStatusList = collection2S.Find(logSort).SortByDescending(x => x.Id).Limit(1).ToList();
            if (nowCamStatusList[0].Datetimetag >= todayTimeTag)
                return nowCamStatusList[0].Status;
            return null;
        }
        
        public string GetConveyerSatus()
        {
            var todayTimeTag=((DateTimeOffset) DateTime.Today).ToUnixTimeSeconds();
            var logSort = Builders<MongoLogDBmodel>.Filter.Eq(x => x.Category , nameof(LEkind.ConveySys) );
            var nowCamStatusList = collection2S.Find(logSort).SortByDescending(x => x.Id).Limit(1).ToList();
            if (nowCamStatusList[0].Datetimetag >= todayTimeTag)
                return nowCamStatusList[0].Status;
            return null;
        }
        
        public string GetRobotArmSatus()
        {
            var todayTimeTag=((DateTimeOffset) DateTime.Today).ToUnixTimeSeconds();
            var logSort = Builders<MongoLogDBmodel>.Filter.Eq(x => x.Category , nameof(LEkind.RobotArm) );
            var nowCamStatusList = collection2S.Find(logSort).SortByDescending(x => x.Id).Limit(1).ToList();
            if (nowCamStatusList[0].Datetimetag >= todayTimeTag)
                return nowCamStatusList[0].Status;
            return null;
        }
        
        public string GetCamSatus()
        {
            var todayTimeTag=((DateTimeOffset) DateTime.Today).ToUnixTimeSeconds();
            // var sinkSort = Builders<MongoPickDBmodel>.Filter.Eq(x => x.Sink , sinksort);

            var logSort = Builders<MongoLogDBmodel>.Filter.Eq(x => x.Category , nameof(LEkind.VisionSys) );
            var nowCamStatusList = collection2S.Find(logSort).SortByDescending(x => x.Id).FirstOrDefault();
             // var result =  nowCamStatusList.FirstOrDefaultAsync();
            //
            // if (result.Result.Datetimetag >= todayTimeTag)
            //     return result.Result.Status;
            if (nowCamStatusList.Datetimetag >= todayTimeTag)
                return nowCamStatusList.Status;
            return "Error";
        }
        
        //R:Read I
        public MongoLogDBmodel Get(long timetag)
        {
            Console.WriteLine("\n--------: DeltaRobotLogModelServices.cs ::--GET--ID !!\n");
            var model1 = Builders<MongoLogDBmodel>.Filter.Eq("Datetimetag", timetag);

            if (model1 == null)
            {
                return null;
            }
            else
            {
                return collection2S.Find(x => ( (x.Datetimetag > (timetag-1000)))).FirstOrDefault();
            }
        }
        
        //U
        public void Update(string id, MongoLogDBmodel moedl1In) =>
            collection2S.ReplaceOne(model1 => model1.Id == id, moedl1In);
        
        //D
        public void Remove(MongoLogDBmodel moedl1In) =>
            collection2S.DeleteOne(model1 => model1.Id == moedl1In.Id); 
        //D
        public void Remove(string id) =>
            collection2S.DeleteOne(model1 => model1.Id == id); 
    }
}