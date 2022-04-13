using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_ASP_Practice3.Models
{
    public class Flag
    {
        public string fl { get; set; }
        private static Flag flag;

        private Flag (string fl)
        {
            this.fl = fl;
        }

        public static Flag GetFlag()
        {
            if (flag == null) flag = new Flag("Customers");
            return flag;
        }
    }
}