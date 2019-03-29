using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;
using BusinessLogic;
using Interfaces;

namespace DressApp.Controllers
{
    public class RentalController : Controller
    {
        private IRentalsManager rentalManager;

        public RentalController()
        {
            rentalManager = new SqlRentalsManager();
        }


        public ActionResult Index(string search, int? page)
        {
            var rentals = rentalManager.GetAll(search, page);
            return View(rentals);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,CustomerId,DressId,DateRented,Customers,Dresses")] Rentals rental)
        {
            if (ModelState.IsValid)
            {
                rentalManager.Save(rental);
                return RedirectToAction("Index");
            }

            return View(rental);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var rental = rentalManager.GetDetailsById(id);
            return View(rental);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var rental = rentalManager.GetDetailsById(id);
            return View(rental);
        }



        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId, CustomerId, DressId, DateRented, Customers, Dresses")] Rentals rental)

        {
            if (ModelState.IsValid)
            {
                rentalManager.Update(rental);
                return RedirectToAction("Index");
            }
            return View(rental);

        }


        

        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                rentalManager.DeleteById(id);
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}