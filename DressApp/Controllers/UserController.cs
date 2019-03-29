using App.Models;
using BusinessLogic;
using Interfaces;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DressApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserManager userManager;

        public UserController()
        {
            userManager = new SqlUserManager();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            string message = " ";
            if (ModelState.IsValid)
            {
                user.Password = Crypto.Hash(user.Password);
                bool isCreated = userManager.CreateUser(user);
                
                return RedirectToAction("LogIn");
            }
            else
            {
                message = "Invalid Request";
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            bool isRegister = userManager.IsRegister(username, password);
            return View();
        }
    }
}