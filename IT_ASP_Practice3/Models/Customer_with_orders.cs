using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_ASP_Practice3.Models
{
    public class Customer_with_orders
    {
        public int orderId { get; set; }
        public string customerName { get; set; }
        public string productName { get; set; }
        public int productCost { get; set; }
    }
}