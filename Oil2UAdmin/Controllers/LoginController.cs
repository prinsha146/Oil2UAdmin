using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace Oil2UAdmin.Controllers
{
    public class LoginController : Controller
    {
        Oil2UEntities entities = new Oil2UEntities();
        // GET: Login
        public ActionResult Index(string returnUrl = "")
        {
            ViewBag.SuccessMessage = "";
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Email, string Password, string returnUrl)
        {
            ViewBag.Message = "";
            ViewBag.SuccessMessage = "";
            var user = entities.Users.Where(x => x.Email == Email && x.Password == Password).SingleOrDefault();
            if (user == null)
            {
                ViewBag.Message = "Username or Password is incorrect.";
                return View();
            }
            else
            {
                Session["UserId"] = user.UserId;
                Session["Email"] = user.Email;
                return RedirectToAction("Index", "Dashboard");
            }
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            ViewBag.Message = "";
            ViewBag.SuccessMessage = "You have logged out successfully!";
            return RedirectToAction("Index", "Login");
        }
    }
}