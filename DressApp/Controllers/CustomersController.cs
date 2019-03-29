using App.Models;
using BusinessLogic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using Interfaces;

namespace DressApp.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomersManager customerManager;

        public CustomersController()
        {
            customerManager = new SqlCustomersManager();
        }



        [HttpGet]
        public ActionResult Index(string search, int? page)
        {
            var rentals = customerManager.GetAll(search, page);
            return View(rentals);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,Email,Phone,Rentals")] Customers customer)
        {
            if (ModelState.IsValid)
            {
                customerManager.Save(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var customer = customerManager.GetDetailsById(id);
            return View(customer);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = customerManager.GetDetailsById(id);
            return View(customer);
        }



        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="CustomerId,FirstName,LastName,Email,Phone,Rentals")] Customers customer)

        {
            if (ModelState.IsValid)
            {
                customerManager.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);

        }



        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                customerManager.DeleteById(id);
                return RedirectToAction("Index");
            }
            return View();

        }







    }
}


    


