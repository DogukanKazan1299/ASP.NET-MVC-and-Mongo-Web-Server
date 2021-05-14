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
    public class CalisanController : Controller
    {
        private CalisanModel calisanModel = new CalisanModel();
       
        [Authorize]
        public ActionResult Index(int ? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;

            var degerler = calisanModel.findAll().ToPagedList(pageNumber, pageSize);

            ViewBag.calisanlar = calisanModel.findAll();
            return View();
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Calisan());
        }





        [HttpPost]
        public ActionResult Add(Calisan calisan)
        {
            calisanModel.create(calisan);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            calisanModel.delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", calisanModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(Calisan calisan,FormCollection fc)
        {
            string id = fc["id"];
            var currentCalisan = calisanModel.find(id);

            if(calisan.Sifre != null)
            {
                currentCalisan.Sifre = calisan.Sifre;
            }

            currentCalisan.Ad = calisan.Ad;
            currentCalisan.Soyad = calisan.Soyad;
            currentCalisan.Sifre = calisan.Sifre;
            currentCalisan.Status = calisan.Status;

            calisanModel.update(currentCalisan);
            return RedirectToAction("Index");
        }

    }
}