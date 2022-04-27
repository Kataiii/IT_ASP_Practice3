using Practice6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice6.Controllers
{
    public class HomeController : Controller
    {
        private PeopleContext db = new PeopleContext();
        private AppCache appCache;

        public HomeController()
        {
            appCache = new AppCache();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult People(string type)
        {
            List<Person> people = new List<Person>();
            if (type == "db")
            {
                foreach (Person person in db.People)
                {
                    people.Add(person);
                }
                appCache.Add(people);
            } 
            else if(type == "cashe")
            {
                // если нет в кэше
                if (appCache.IsEmpty() == true)
                {
                    return PartialView("NotFind");
                }
                return PartialView("People", appCache.GetPeople());
            }
            return PartialView("People", people);
        }
    }
}