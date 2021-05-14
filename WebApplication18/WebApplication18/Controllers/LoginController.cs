using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Entities;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class LoginController : Controller
    {
        private LoginModel loginModel = new LoginModel();


        public ActionResult Index()
        {
            ViewBag.loginler = loginModel.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Login());
        }





        [HttpPost]
        public ActionResult Add(Login login)
        {
            loginModel.create(login);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            loginModel.delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", loginModel.find(id));
        }


        [HttpPost]
        public ActionResult Edit(Login login, FormCollection fc)
        {
            string id = fc["id"];
            var currentLogin = loginModel.find(id);

            
            currentLogin.Ad = login.Ad;
            currentLogin.Soyad = login.Soyad;
            currentLogin.Sifre = login.Sifre;



            loginModel.update(currentLogin);
            return RedirectToAction("Index");
        }
    }
}