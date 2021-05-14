using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication18.Entities
{
    public class Depo
    {

        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        [BsonElement("urunadi")]
        public String urunadi
        {
            get;
            set;
        }


        [BsonElement("depono")]
        public String depono
        {
            get;
            set;
        }


        [BsonElement("depoadres")]
        public String depoadres
        {
            get;
            set;
        }





    }
}