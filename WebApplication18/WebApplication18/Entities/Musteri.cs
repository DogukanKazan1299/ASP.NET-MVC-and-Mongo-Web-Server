using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace WebApplication18.Entities
{
    public class Musteri
    {

        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        [BsonElement("ad")]
        [Required(ErrorMessage ="Ad boş geçilemez")]
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

        [BsonElement("ucret")]
        public string Ucret
        {
            get;
            set;
        }



        [BsonElement("adres")]
        public string Adres
        {
            get;
            set;
        }
    }
}