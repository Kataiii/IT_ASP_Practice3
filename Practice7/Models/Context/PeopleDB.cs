using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practice7.Models.Context
{
    public class PeopleDB : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}