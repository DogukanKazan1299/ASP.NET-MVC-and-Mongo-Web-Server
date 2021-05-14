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
    public class CalisanModel
    {

        private MongoClient mongoClient;
        private IMongoCollection<Calisan> calisanCollection;

        public CalisanModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            calisanCollection = db.GetCollection<Calisan>("calisan");
        }



        public List<Calisan> findAll()
        {
            return calisanCollection.AsQueryable<Calisan>().ToList();
        }


        public Calisan find(string id)
        {
            var calisanId = new ObjectId(id);
            return calisanCollection.AsQueryable<Calisan>().SingleOrDefault(a => a.Id == calisanId);
        }


        public void create(Calisan calisan)
        {
            calisanCollection.InsertOne(calisan);
        }


        public void update(Calisan calisan)
        {
            calisanCollection.UpdateOne(Builders<Calisan>.Filter.Eq("_id", calisan.Id), Builders<Calisan>.Update
                .Set("ad",calisan.Ad)
                .Set("soyad", calisan.Soyad)
                .Set("sifre", calisan.Sifre)
                .Set("status", calisan.Status)
                );
        }


        public void delete(string id)
        {
            calisanCollection.DeleteOne(Builders<Calisan>.Filter.Eq("_id", ObjectId.Parse(id)));
        }


    }
}