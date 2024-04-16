using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oil2UAdmin.Controllers
{
    public class OrderController : Controller
    {
        Oil2UEntities entities = new Oil2UEntities();

        // GET: Delivery
        public ActionResult Index()
        {
            var orderList = entities.Orders.ToList();
            return View(orderList);
        }
    }
}