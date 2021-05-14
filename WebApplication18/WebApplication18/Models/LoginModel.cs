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
    public class LoginModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Login> loginCollection;

        public LoginModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            loginCollection = db.GetCollection<Login>("login");
        }



        public List<Login> findAll()
        {
            return loginCollection.AsQueryable<Login>().ToList();
        }


        public Login find(string id)
        {
            var loginId = new ObjectId(id);
            return loginCollection.AsQueryable<Login>().SingleOrDefault(a => a.Id == loginId);
        }


        public void create(Login login)
        {
            loginCollection.InsertOne(login);
        }


        public void update(Login login)
        {
            loginCollection.UpdateOne(Builders<Login>.Filter.Eq("_id", login.Id), Builders<Login>.Update
                .Set("ad", login.Ad)
                .Set("soyad", login.Soyad)
                .Set("sifre", login.Sifre)
                
                );
        }


        public void delete(string id)
        {
            loginCollection.DeleteOne(Builders<Login>.Filter.Eq("_id", ObjectId.Parse(id)));
        }

    }
}