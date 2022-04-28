using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice6_3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Master()
        {
            return View();
        }

        public ActionResult FirstPage()
        {
            return View();
        }

        public ActionResult SecondPage()
        {
            return View();
        }

        public ActionResult Router_pages(string nextPage)
        {
            switch (nextPage)
            {
                case "first_page":
                    return View("FirstPage");
                case "second_page":
                    return View("SecondPage");
            }
            return View("Master");
        }
    }
}