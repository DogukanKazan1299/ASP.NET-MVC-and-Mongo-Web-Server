using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class MaasController : Controller
    {
        private MaasModel maasModel = new MaasModel();

        public ActionResult Index()
        {
            ViewBag.maaslar = maasModel.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Maas());
        }





        [HttpPost]
        public ActionResult Add(Maas maas)
        {
            maasModel.create(maas);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            maasModel.delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", maasModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(Maas maas, FormCollection fc)
        {
            string id = fc["id"];
            var currentMaas = maasModel.find(id);

            

            currentMaas.Calisanid = maas.Calisanid;
            currentMaas.Calisanmaas = maas.Calisanmaas;
            

            maasModel.update(currentMaas);
            return RedirectToAction("Index");
        }
    }
}