using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CC_1.Models;

namespace MVC_CC_1.Controllers
{
    public class CodeController : Controller
    {
        NorthWindEntities db = new NorthWindEntities();

        // GET: Action
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cust_in_Germany()
        {
            var Customers = (from c in db.Customers where c.Country == "Germany" select c).ToList();
            return View(Customers);
        }

        public ActionResult Cust_with_ID()
        {
            var order = db.Orders.Find(10248);
            var customer = order != null ? order.Customer : null;
            return View(customer);
        }
    }
}