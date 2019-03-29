using App.Models;
using BusinessLogic;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressApp.Controllers
{
    public class DressesController : Controller
    {
        private IDressManager dressManager;

        public DressesController()
        {
            dressManager = new SqlDressManager();
        }


        

        [HttpGet]
        public ActionResult Index(string search, int? page)
        {
            var dresses = dressManager.GetAll(search, page);
            return View(dresses);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DressId,Title,Style,Size,Brand,Length,Price,Colour")] Dresses dress)
        {
            if (ModelState.IsValid)
            {
                dressManager.Save(dress);
                return RedirectToAction("Index");
            }

            return View(dress);
        }





        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dress = dressManager.GetDetailsById(id);
            return View(dress);
        }



        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DressId,Title,Style,Size,Brand,Length,Price,Colour")] Dresses dress)

        {
            if (ModelState.IsValid)
            {
                dressManager.Update(dress);
                return RedirectToAction("Index");
            }
            return View(dress);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dress = dressManager.GetDetailsById(id);
            return View(dress);
        }



        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                dressManager.DeleteById(id);
                return RedirectToAction("Index");
            }
            return View();

        }



    }
}