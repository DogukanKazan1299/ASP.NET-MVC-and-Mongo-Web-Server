using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class RaporlarController : Controller
    {
        private RaporlarModel raporlarModel = new RaporlarModel();

        public ActionResult Index()
        {
            ViewBag.raporlar = raporlarModel.findAll();
            return View();
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Raporlar());
        }





        [HttpPost]
        public ActionResult Add(Raporlar raporlar)
        {
            raporlarModel.create(raporlar);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            raporlarModel.delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", raporlarModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(Raporlar raporlar, FormCollection fc)
        {
            string id = fc["id"];
            var currentRaporlar = raporlarModel.find(id);

           
            currentRaporlar.Neden = raporlar.Neden;
            currentRaporlar.Musteriid = raporlar.Musteriid;
            currentRaporlar.Musteriyorum = raporlar.Musteriyorum;


            raporlarModel.update(currentRaporlar);
            return RedirectToAction("Index");
        }

    }
}