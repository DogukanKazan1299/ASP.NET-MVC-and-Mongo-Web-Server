using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;
using PagedList;
using PagedList.Mvc;


namespace WebApplication18.Controllers
{
    public class MusteriController : Controller
    {
        private MusteriModel musteriModel = new MusteriModel();

        public ActionResult Index(string ara)
        {
            //ViewBag.musteriler = musteriModel.findAll().Where(x=>x.Ad.Contains(ara));
            ViewBag.musteriler = musteriModel.findAll();
            if (!string.IsNullOrEmpty(ara))
            {
                ViewBag.musteriler = musteriModel.findAll().Where(x => x.Ad.Contains(ara));

            }
            return View();
        }




        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Musteri());
        }





        [HttpPost]
        public ActionResult Add(Musteri musteri)
        {
            musteriModel.create(musteri);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            musteriModel.delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", musteriModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(Musteri musteri, FormCollection fc)
        {
            string id = fc["id"];
            var currentMusteri = musteriModel.find(id);

           

            currentMusteri.Ad = musteri.Ad;
            currentMusteri.Soyad = musteri.Soyad;
            currentMusteri.Ucret = musteri.Ucret;
            currentMusteri.Adres = musteri.Adres;




            musteriModel.update(currentMusteri);
            return RedirectToAction("Index");
        }

    }
}