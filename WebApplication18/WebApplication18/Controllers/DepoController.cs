using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class DepoController : Controller
    {
        private DepoModel depoModel = new DepoModel();

        public ActionResult Index()
        {
            ViewBag.depolar = depoModel.findAll();
            return View();
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Depo());
        }





        [HttpPost]
        public ActionResult Add(Depo depo)
        {
            depoModel.create(depo);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            depoModel.delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", depoModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(Depo depo, FormCollection fc)
        {
            string id = fc["id"];
            var currentDepo = depoModel.find(id);

            

            currentDepo.urunadi = depo.urunadi;
            currentDepo.depono = depo.depono;
            currentDepo.depoadres = depo.depoadres;
            

            depoModel.update(depo);
            return RedirectToAction("Index");
        }

    }
}