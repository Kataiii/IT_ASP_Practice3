using IT_ASP_Practice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_ASP_Practice3.Controllers
{
    public class HomeController : Controller
    {
        OrderContext db = new OrderContext();

        // GET: Home
        public ActionResult ControlPanel()
        {
            return View();
        }

        private ViewResult ViewCustomers()
        {
            return View(db.Customers);
        }

        [HttpPost]
        public void ActionCustomer(string action)
        {
            if(action == "view")
            {
                ViewCustomers();
            }
            if(action == "add")
            {

            }
            if(action == "update")
            {

            }
            if(action == "delete")
            {

            }
        }
    }
}