using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication18.Entities
{
    public class İş
    {

        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }



        [BsonElement("urunadi")]
        public string Urunadi
        {
            get;
            set;
        }



        [BsonElement("satistoplam")]
        public string Satistoplam
        {
            get;
            set;
        }



        [BsonElement("ucret")]
        public string Ucret
        {
            get;
            set;
        }


    }
}