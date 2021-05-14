using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication18.Entities
{
    public class Calisan
    {
        
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }
        
        
        [BsonElement("ad")]
        public string Ad
        {
            get;
            set;
        }

        [BsonElement("soyad")]
        public string Soyad
        {
            get;
            set;
        }

        [BsonElement("sifre")]
        public string Sifre
        {
            get;
            set;
        }

        [BsonElement("status")]
        public bool Status
        {
            get;
            set;
        }

    }
}