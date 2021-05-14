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
    public class MusteriModel
    {



        private MongoClient mongoClient;
        private IMongoCollection<Musteri> musteriCollection;

        public MusteriModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            musteriCollection = db.GetCollection<Musteri>("musteri");
        }



        public List<Musteri> findAll()
        {
            return musteriCollection.AsQueryable<Musteri>().ToList();
        }


        public Musteri find(string id)
        {
            var musteriId = new ObjectId(id);
            return musteriCollection.AsQueryable<Musteri>().SingleOrDefault(a => a.Id == musteriId);
        }


        public void create(Musteri musteri)
        {
            musteriCollection.InsertOne(musteri);
        }


        public void update(Musteri musteri)
        {
            musteriCollection.UpdateOne(Builders<Musteri>.Filter.Eq("_id", musteri.Id), Builders<Musteri>.Update
                .Set("ad", musteri.Ad)
                .Set("soyad", musteri.Soyad)
                .Set("ucret", musteri.Ucret)
                .Set("adres", musteri.Adres)

                );
        }


        public void delete(string id)
        {
            musteriCollection.DeleteOne(Builders<Musteri>.Filter.Eq("_id", ObjectId.Parse(id)));
        }





    }
}