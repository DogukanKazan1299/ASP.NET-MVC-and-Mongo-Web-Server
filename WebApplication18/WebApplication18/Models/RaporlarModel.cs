using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication18.Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace WebApplication18.Models
{
    public class RaporlarModel
    {


        private MongoClient mongoClient;
        private IMongoCollection<Raporlar> raporlarCollection;

        public RaporlarModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            raporlarCollection = db.GetCollection<Raporlar>("raporlar");
        }



        public List<Raporlar> findAll()
        {
            return raporlarCollection.AsQueryable<Raporlar>().ToList();
        }


        public Raporlar find(string id)
        {
            var raporlarId = new ObjectId(id);
            return raporlarCollection.AsQueryable<Raporlar>().SingleOrDefault(a => a.Id == raporlarId);
        }


        public void create(Raporlar raporlar)
        {
            raporlarCollection.InsertOne(raporlar);
        }


        public void update(Raporlar raporlar)
        {
            raporlarCollection.UpdateOne(Builders<Raporlar>.Filter.Eq("_id", raporlar.Id), Builders<Raporlar>.Update
                .Set("neden", raporlar.Neden)
                .Set("musteriid", raporlar.Musteriid)
                .Set("musteriyorum", raporlar.Musteriyorum)
                );
        }


        public void delete(string id)
        {
            raporlarCollection.DeleteOne(Builders<Raporlar>.Filter.Eq("_id", ObjectId.Parse(id)));
        }





    }
}