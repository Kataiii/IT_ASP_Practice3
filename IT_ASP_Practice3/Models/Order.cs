using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_ASP_Practice3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}