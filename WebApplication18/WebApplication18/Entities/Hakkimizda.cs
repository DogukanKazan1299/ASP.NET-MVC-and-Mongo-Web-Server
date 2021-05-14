using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication18.Entities
{
    public class Hakkimizda
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }


        [BsonElement("metin")]
        public string Metin
        {
            get;
            set;
        }
    }
}