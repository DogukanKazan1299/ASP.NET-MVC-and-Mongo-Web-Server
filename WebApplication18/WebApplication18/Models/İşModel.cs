using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication18.Entities;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;

namespace WebApplication18.Models
{
    public class İşModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<İş> işCollection;


        public İşModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            işCollection = db.GetCollection<İş>("iş");
        }

        public List<İş> findAll()
        {
            return işCollection.AsQueryable<İş>().ToList();
        }

        public İş find(string id)
        {
            var işId = new ObjectId(id);
            return işCollection.AsQueryable<İş>().SingleOrDefault(a => a.Id == işId);

        }

        public void create(İş iş)
        {
            işCollection.InsertOne(iş);
        }

        public void update(İş iş)
        {
           işCollection.UpdateOne(Builders<İş>.Filter.Eq("_id", iş.Id), Builders<İş>.Update
                .Set("urunadi", iş.Urunadi)
                .Set("satistoplam", iş.Satistoplam)
                .Set("ucret", iş.Ucret)

                );
        }
        public void delete(string id)
        {
            işCollection.DeleteOne(Builders<İş>.Filter.Eq("_id", ObjectId.Parse(id)));
        }


    }


       
}