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
    public class HakkimizdaModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Hakkimizda> hakkimizdaCollection;

        public HakkimizdaModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            hakkimizdaCollection = db.GetCollection<Hakkimizda>("hakkimizda");
        }


        public List<Hakkimizda> findAll()
        {
            return hakkimizdaCollection.AsQueryable<Hakkimizda>().ToList();
        }


        public Hakkimizda find(string id)
        {
            var hakkimizdaId = new ObjectId(id);
            return hakkimizdaCollection.AsQueryable<Hakkimizda>().SingleOrDefault(a => a.Id == hakkimizdaId);
        }

        public void create(Hakkimizda hakkimizda)
        {
            hakkimizdaCollection.InsertOne(hakkimizda);
        }


        public void update(Hakkimizda hakkimizda)
        {
            hakkimizdaCollection.UpdateOne(Builders<Hakkimizda>.Filter.Eq("_id", hakkimizda.Id), Builders<Hakkimizda>.Update
                .Set("metin", hakkimizda.Metin)
                

                );
        }


        public void delete(string id)
        {
            hakkimizdaCollection.DeleteOne(Builders<Hakkimizda>.Filter.Eq("_id", ObjectId.Parse(id)));
        }



    }
}