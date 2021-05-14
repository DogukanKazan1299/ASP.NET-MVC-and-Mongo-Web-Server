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
    public class MaasModel
    {

        private MongoClient mongoClient;
        private IMongoCollection<Maas> maasCollection;

        public MaasModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            maasCollection = db.GetCollection<Maas>("maas");
        }



        public List<Maas> findAll()
        {
            return maasCollection.AsQueryable<Maas>().ToList();
        }


        public Maas find(string id)
        {
            var maasId = new ObjectId(id);
            return maasCollection.AsQueryable<Maas>().SingleOrDefault(a => a.Id == maasId);
        }


        public void create(Maas maas)
        {
            maasCollection.InsertOne(maas);
        }


        public void update(Maas maas)
        {
            maasCollection.UpdateOne(Builders<Maas>.Filter.Eq("_id", maas.Id), Builders<Maas>.Update
                .Set("calisanid", maas.Calisanid)
                .Set("calisanmaas", maas.Calisanmaas)
                
                );
        }


        public void delete(string id)
        {
            maasCollection.DeleteOne(Builders<Maas>.Filter.Eq("_id", ObjectId.Parse(id)));
        }




    }
}