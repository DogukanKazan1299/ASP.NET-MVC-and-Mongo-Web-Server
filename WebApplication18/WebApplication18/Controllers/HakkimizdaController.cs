using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class HakkimizdaController : Controller
    {
        private HakkimizdaModel hakkimizdaModel = new HakkimizdaModel();
        
        public ActionResult Index()
        {
            ViewBag.hakkimizdalar = hakkimizdaModel.findAll();
            return View();
        }



        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Hakkimizda());
        }





        [HttpPost]
        public ActionResult Add(Hakkimizda hakkimizda)
        {
            hakkimizdaModel.create(hakkimizda);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            hakkimizdaModel.delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", hakkimizdaModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(Hakkimizda hakkimizda, FormCollection fc)
        {
            string id = fc["id"];
            var currentDepo = hakkimizdaModel.find(id);



            currentDepo.Metin = hakkimizda.Metin;
            


            hakkimizdaModel.update(hakkimizda);
            return RedirectToAction("Index");
        }
    }
}