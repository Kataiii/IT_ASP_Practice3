using Practice7.Models;
using Practice7.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice7.Controllers
{
    public class HomeController : Controller
    {
        PeopleDB db = new PeopleDB();

        // GET: Home
        public ActionResult Invitation()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Form(string notCorrect)
        {
            ViewBag.NotCorrect = notCorrect;
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Regret()
        {
            return View();
        }

        public ActionResult ShowGuests()
        {
            return View(db.People);
        }

        public ActionResult Router_pages(string page)
        {
            switch (page)
            {
                case "form":
                    return View("Form");
                case "show":
                    return View("ShowGuests", db.People);
            }
            return View("Invitation");
        }

        [HttpPost]
        public ActionResult Form(PersonResponse personResponse)
        {
            if (ModelState.IsValid)
            {
                var personFind = db.People.FirstOrDefault<Person>((client) => client.Phone.Equals(personResponse.Phone));
                if (personFind == null)
                {
                    var person = new Person(personResponse.Name, personResponse.Phone, personResponse.Answer);
                    
                    db.People.Add(person);
                    personFind = person;
                }
                else
                {
                    personFind.Name = personResponse.Name;
                    personFind.Answer = personResponse.Answer;

                    db.Entry(personFind).State = EntityState.Modified;
                }
                db.SaveChanges();
                if (personFind.Answer == true) return View("Welcome");
                else return View("Regret");
            }
            else return Form("Incorrectly entered data");
        }
    }
}