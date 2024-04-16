using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oil2UAdmin.Controllers
{
    public class UsersController : Controller
    {
        Oil2UEntities entities = new Oil2UEntities();
        // GET: Users
        public ActionResult Index()
        {
            var userList = entities.Users.ToList();
            return View(userList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            entities.Users.Add(user);
            entities.SaveChanges();
            ViewBag.Message = "Data Insert Successful";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = entities.Users.Where(x => x.UserId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var data = entities.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (data != null)
            {
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.Email = user.Email;
                data.Address = user.Address;
                data.CompanyName = user.CompanyName;
                data.Password = user.Password;
                data.PhoneNo = user.PhoneNo;
                data.UserName = user.UserName;
                entities.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = entities.Users.Where(x => x.UserId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = entities.Users.Where(x => x.UserId == id).FirstOrDefault();
            entities.Users.Remove(data);
            entities.SaveChanges();
            ViewBag.Message = "User Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}