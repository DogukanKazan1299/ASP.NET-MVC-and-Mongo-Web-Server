using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class LogInYapController : Controller
    {
        private MongoClient mongoClient;
        private IMongoCollection<Login> loginCollection;

        public LogInYapController()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            loginCollection = db.GetCollection<Login>("login");
        }


        // GET: LogInYap
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
        public ActionResult Index(LoginModel ad)
        {

            //var bilgiler = c.Admins.FirstOrDefault(x => x.Ad == ad.Ad && x.sifre == ad.sifre);
            
            /*if (bilgiler != null)
            {

                FormsAuthentication.SetAuthCookie(bilgiler.Ad, false);
                Session["Ad"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "LogInYap");
            }*/



            return View();
        }

		}
}