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
            OrderContextMain orderContextMain = new OrderContextMain();
            orderContextMain.Customers = db.Customers;
            orderContextMain.customer_With_Orders = SelectCustomersWithrders();
            orderContextMain.Orders = db.Orders;
            orderContextMain.Products = db.Products;
            return View(orderContextMain);
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

        private IQueryable<Customer_with_orders> SelectCustomersWithrders()
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
            return customers_With_Orders;
        }

        public ActionResult Customers_with_orders()
        {
            OrderContextFull orderContextFull = new OrderContextFull();
            orderContextFull.customer_With_Orders = SelectCustomersWithrders();
            orderContextFull.Products = db.Products;
            return View(orderContextFull);

        }

        public ActionResult ControlPanelFull()
        {
            OrderContextFull orderContextFull = new OrderContextFull();
            orderContextFull.customer_With_Orders = SelectCustomersWithrders();
            orderContextFull.Products = db.Products;
            return View(orderContextFull);
        }

        [OutputCache (Duration =30, Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Check_RadioButton(string customer)
        {
            if (customer == "not_orders")
            {
                OrderContextMain orderContextMain = new OrderContextMain();
                orderContextMain.Customers = db.Customers;
                orderContextMain.customer_With_Orders = SelectCustomersWithrders();
                orderContextMain.Orders = db.Orders;
                orderContextMain.Products = db.Products;
                return View("ControlPanel", orderContextMain);
            }
            OrderContextFull orderContextFull = new OrderContextFull();
            orderContextFull.customer_With_Orders = SelectCustomersWithrders();
            orderContextFull.Products = db.Products;
            return View("ControlPanelFull", orderContextFull);
        }

        //Database Queries
        //Customers
        private void AddCustomer(string name)
        {
            var newCustomer = new Customer
            {
                Id = 1,
                Name = name
            };
            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        private bool UpdateCustomer(string id, string name)
        {
            if (id == null || id == "")
            {
                return false;
            }
            Customer customer = db.Customers.Find(int.Parse(id));
            if (customer == null) return false;
            customer.Name = name;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        private bool DeleteCustomer(string id)
        {
            if (id == null || id == "")
            {
                return false;
            }
            Customer customer_del = db.Customers.Find(int.Parse(id));
            if (customer_del != null)
            {
                db.Customers.Remove(customer_del);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Products
        private void AddProduct(string name,string cost)
        {
            var newProduct = new Product
            {
                Id = 1,
                Name = name,
                Cost = int.Parse(cost)
            };
            db.Products.Add(newProduct);
            db.SaveChanges();
        }

        private bool UpdateProduct(string id, string name, string cost)
        {
            if (id == null || id == "")
            {
                return false;
            }
            Product product = db.Products.Find(int.Parse(id));
            if (product == null) return false;
            if (name!="") product.Name = name;
            if (cost != "") product.Cost = int.Parse(cost);
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        private bool DeleteProduct(string id)
        {
            if (id == null || id == "")
            {
                return false;
            }
            Product product_del = db.Products.Find(int.Parse(id));
            if (product_del != null)
            {
                db.Products.Remove(product_del);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Orders
        private void AddOrder(string idCustomer,string idProduct)
        {
            var newOrder = new Order
            {
                Id = 1,
                CustomerId = int.Parse(idCustomer),
                ProductId = int.Parse(idProduct)
            };
            db.Orders.Add(newOrder);
            db.SaveChanges();
        }

        private bool UpdateOrder(string id, string idCustomer,string idProduct)
        {
            if (id == null || id == "")
            {
                return false;
            }
            Order order = db.Orders.Find(int.Parse(id));
            if (order == null) return false;
            if (idCustomer != "") order.CustomerId = int.Parse(idCustomer);
            if (idProduct != "") order.ProductId = int.Parse(idProduct);
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        private bool DeleteOrder(string id)
        {
            if (id == null || id == "")
            {
                return false;
            }
            Order order_del = db.Orders.Find(int.Parse(id));
            if (order_del != null)
            {
                db.Orders.Remove(order_del);
                db.SaveChanges();
                return true;
            }
            return false;
        }


        //Controllers for Customers
        [HttpPost]
        public ActionResult ActionCustomer(string action)
         {
            switch (action)
            {
                case "add":
                    AddCustomer(Request.Form["new_user_name"]);
                    break;
                case "update":
                    if (!UpdateCustomer(Request.Form["id_user_update"], Request.Form["name_user_update"])) return View("ViewError");
                    break;
                case "delete":
                    if (!DeleteCustomer(Request.Form["id_user_delete"])) return View("ViewError");
                    break;
            }
            OrderContextMain orderContextMain = new OrderContextMain();
            orderContextMain.Customers = db.Customers;
            orderContextMain.customer_With_Orders = SelectCustomersWithrders();
            orderContextMain.Orders = db.Orders;
            orderContextMain.Products = db.Products;
            return View("ControlPanel", orderContextMain);
         }


        [HttpPost]
        public ActionResult ActionCustomerFull(string action)
        {
            switch (action)
            {
                case "add":
                    AddCustomer(Request.Form["new_user_name"]);
                    break;
                case "update":
                    if (!UpdateCustomer(Request.Form["id_user_update"], Request.Form["name_user_update"])) return View("ViewError");
                    break;
                case "delete":
                    if (!DeleteCustomer(Request.Form["id_user_delete"])) return View("ViewError");
                    break;
            }
            OrderContextFull orderContextFull = new OrderContextFull();
            orderContextFull.customer_With_Orders = SelectCustomersWithrders();
            orderContextFull.Products = db.Products;
            return View("ControlPanelFull", orderContextFull);
        }

        //Controllers for products

        public ActionResult Products()
        {
            return View(db.Products);
        }

        [HttpPost]
        public ActionResult ActionProducts(string action)
        {
            switch (action)
            {
                case "add":
                    AddProduct(Request.Form["new_product_name"], Request.Form["new_product_cost"]);
                    break;
                case "update":
                    if (!UpdateProduct(Request.Form["id_product_update"], 
                                        Request.Form["update_product_name"], 
                                        Request.Form["update_product_cost"]))
                    {
                        return View("ViewError");
                    }
                    break;
                case "delete":
                    if(!DeleteProduct(Request.Form["id_product_delete"])) return View("ViewError");
                    break;
            }
            OrderContextMain orderContextMain = new OrderContextMain();
            orderContextMain.Customers = db.Customers;
            orderContextMain.customer_With_Orders = SelectCustomersWithrders();
            orderContextMain.Orders = db.Orders;
            orderContextMain.Products = db.Products;
            return View("ControlPanel", orderContextMain);
        }

        [HttpPost]
        public ActionResult ActionProductsFull(string action)
        {
            switch (action)
            {
                case "add":
                    AddProduct(Request.Form["new_product_name"], Request.Form["new_product_cost"]);
                    break;
                case "update":
                    if (!UpdateProduct(Request.Form["id_product_update"],
                                        Request.Form["update_product_name"],
                                        Request.Form["update_product_cost"]))
                    {
                        return View("ViewError");
                    }
                    break;
                case "delete":
                    if (!DeleteProduct(Request.Form["id_product_delete"])) return View("ViewError");
                    break;
            }
            OrderContextFull orderContextFull = new OrderContextFull();
            orderContextFull.customer_With_Orders = SelectCustomersWithrders();
            orderContextFull.Products = db.Products;
            return View("ControlPanelFull", orderContextFull);
        }

        //Controllers for orders
        public ActionResult ActionOrders(string action)
        {
            switch (action)
            {
                case "add":
                    AddOrder(Request.Form["new_order_idCustomer"], Request.Form["new_order_idProduct"]);
                    break;
                case "update":
                    if (!UpdateOrder(Request.Form["id_order_update"],
                                        Request.Form["update_order_idCustomer"],
                                        Request.Form["update_order_idProduct"]))
                    {
                        return View("ViewError");
                    }
                    break;
                case "delete":
                    if (!DeleteOrder(Request.Form["id_order_delete"])) return View("ViewError");
                    break;
            }
            OrderContextMain orderContextMain = new OrderContextMain();
            orderContextMain.Customers = db.Customers;
            orderContextMain.customer_With_Orders = SelectCustomersWithrders();
            orderContextMain.Orders = db.Orders;
            orderContextMain.Products = db.Products;
            return View("ControlPanel", orderContextMain);
        }


        public ActionResult ActionOrdersFull(string action)
        {
            switch (action)
            {
                case "add":
                    AddOrder(Request.Form["new_order_idCustomer"], Request.Form["new_order_idProduct"]);
                    break;
                case "update":
                    if (!UpdateOrder(Request.Form["id_order_update"],
                                        Request.Form["update_order_idCustomer"],
                                        Request.Form["update_order_idProduct"]))
                    {
                        return View("ViewError");
                    }
                    break;
                case "delete":
                    if (!DeleteOrder(Request.Form["id_order_delete"])) return View("ViewError");
                    break;
            }
            OrderContextFull orderContextFull = new OrderContextFull();
            orderContextFull.customer_With_Orders = SelectCustomersWithrders();
            orderContextFull.Products = db.Products;
            return View("ControlPanelFull", orderContextFull);
        }

        public ActionResult ViewError()
        {
            return View();
        }

        public ActionResult TryAgain()
        {
            OrderContextMain orderContextMain = new OrderContextMain();
            orderContextMain.Customers = db.Customers;
            orderContextMain.customer_With_Orders = SelectCustomersWithrders();
            orderContextMain.Orders = db.Orders;
            orderContextMain.Products = db.Products;
            return View("ControlPanel", orderContextMain);
        }
    }
}