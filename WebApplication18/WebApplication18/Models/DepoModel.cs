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
    public class DepoModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Depo> depoCollection;


        public DepoModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            depoCollection = db.GetCollection<Depo>("depo");
        }


        public List<Depo> findAll()
        {
            return depoCollection.AsQueryable<Depo>().ToList();
        }


        public Depo find(string id)
        {
            var depoId = new ObjectId(id);
            return depoCollection.AsQueryable<Depo>().SingleOrDefault(a => a.Id == depoId);
        }




        public void create(Depo depo)
        {
            depoCollection.InsertOne(depo);
        }


        public void update(Depo depo)
        {
            depoCollection.UpdateOne(Builders<Depo>.Filter.Eq("_id", depo.Id), Builders<Depo>.Update
                .Set("urunadi", depo.urunadi)
                .Set("depono", depo.depono)
                .Set("depoadres", depo.depoadres)
                
                );
        }


        public void delete(string id)
        {
            depoCollection.DeleteOne(Builders<Depo>.Filter.Eq("_id", ObjectId.Parse(id)));
        }




    }











}