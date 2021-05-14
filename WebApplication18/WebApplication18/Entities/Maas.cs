using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication18.Entities
{
    public class Maas
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        [BsonElement("calisanid")]
        public string Calisanid
        {
            get;
            set;
        }

        [BsonElement("calisanmaas")]
        public string Calisanmaas
        {
            get;
            set;
        }
    }
}