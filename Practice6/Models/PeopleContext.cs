using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practice6.Models
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set;  }
    }
}