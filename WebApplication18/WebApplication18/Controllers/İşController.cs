using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Models;
using WebApplication18.Entities;


namespace WebApplication18.Controllers
{
    public class İşController : Controller
    {
        private İşModel işModel = new İşModel();
        public ActionResult Index()
        {
            ViewBag.işler = işModel.findAll();
            return View();
        }




        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new İş());
        }



        [HttpPost]
        public ActionResult Add(İş iş)
        {
            işModel.create(iş);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            işModel.delete(id);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", işModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(İş iş,FormCollection fc)
        {
            string id = fc["id"];
            var currentİş = işModel.find(id);

            currentİş.Urunadi = iş.Urunadi;
            currentİş.Satistoplam = iş.Satistoplam;
            currentİş.Ucret = iş.Ucret;


            işModel.update(currentİş);
            return RedirectToAction("Index");

        }




    }
}