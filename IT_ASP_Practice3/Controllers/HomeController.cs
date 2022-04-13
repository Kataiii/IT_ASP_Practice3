using IT_ASP_Practice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace IT_ASP_Practice3.Controllers
{
    public class HomeController : Controller
    {
        OrderContext db = new OrderContext();

        // GET: Home
        public ActionResult ControlPanel()
        {
            var customers = db.Customers;
            return View(customers);
        }

        [HttpGet]
        public ActionResult ActionCustomer()
        {
            return View(db.Customers);
        }

        public ActionResult Customers()
        {
            return View(db.Customers);
        }

        public ActionResult Orders()
        {
            return View(db.Orders);
        }

        public ActionResult Customers_with_orders()
        {
            var customers_With_Orders = from o in db.Orders
                                        join c in db.Customers on o.CustomerId equals c.Id into temp1
                                        from t1 in temp1.DefaultIfEmpty()
                                        join p in db.Products on o.ProductId equals p.Id into temp2
                                        from t2 in temp2.DefaultIfEmpty()
                                        select new Customer_with_orders
                                        {
                                            orderId = o.Id,
                                            customerName = t1.Name,
                                            productName = t2.Name,
                                            productCost = t2.Cost
                                        };

            return View(customers_With_Orders);

        }

        public ActionResult ControlPanelFull()
        {
            var customers_With_Orders = from o in db.Orders
                                        join c in db.Customers on o.CustomerId equals c.Id into temp1
                                        from t1 in temp1.DefaultIfEmpty()
                                        join p in db.Products on o.ProductId equals p.Id into temp2
                                        from t2 in temp2.DefaultIfEmpty()
                                        select new Customer_with_orders
                                        {
                                            orderId = o.Id,
                                            customerName = t1.Name,
                                            productName = t2.Name,
                                            productCost = t2.Cost
                                        };

            return View(customers_With_Orders);
        }

        public ActionResult Check_RadioButton(string customer)
        {
            if (customer == "not_orders") return View("ControlPanel",db.Customers);
            var customers_With_Orders = from o in db.Orders
                                        join c in db.Customers on o.CustomerId equals c.Id into temp1
                                        from t1 in temp1.DefaultIfEmpty()
                                        join p in db.Products on o.ProductId equals p.Id into temp2
                                        from t2 in temp2.DefaultIfEmpty()
                                        select new Customer_with_orders
                                        {
                                            orderId = o.Id,
                                            customerName = t1.Name,
                                            productName = t2.Name,
                                            productCost = t2.Cost
                                        };

            return View("ControlPanelFull",customers_With_Orders);
        }


        [HttpPost]
         public ActionResult ActionCustomer(string action)
         {
            switch (action)
            {
                case "add":
                    var newCustomer = new Customer
                    {
                        Id = 1,
                        Name = Request.Form["new_user_name"]
                    };
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    break;
                case "update":
                    if(Request.Form["id_user_update"]==null|| Request.Form["id_user_update"] == "")
                    {
                        return HttpNotFound();
                    }
                    Customer customer = db.Customers.Find(int.Parse(Request.Form["id_user_update"]));
                    customer.Name = Request.Form["name_user_update"];
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    break;
            }
            return View("ControlPanel", db.Customers);
         }
    }
}