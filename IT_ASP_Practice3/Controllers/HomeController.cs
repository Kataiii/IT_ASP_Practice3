using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_ASP_Practice3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult ControlPanel()
        {
            return View();
        }
    }
}