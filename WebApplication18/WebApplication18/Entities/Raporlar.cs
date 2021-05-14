using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication18.Entities
{
    public class Raporlar
    {

        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        [BsonElement("neden")]
        public string Neden
        {
            get;
            set;
        }

        [BsonElement("musteriid")]
        public string Musteriid
        {
            get;
            set;
        }

        [BsonElement("musteriyorum")]
        public string Musteriyorum
        {
            get;
            set;
        }




    }
}