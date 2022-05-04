using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice7.Models
{
    public class Person
    {
        public string Name { get; set; }
        [Key]
        public string Phone { get; set; }
        public bool Answer { get; set; }

        public Person() { }
        public Person(string Name, string Phone, string Answer) : this(Name, Phone, bool.Parse(Answer)){}

        public Person(string name, string phone, bool answer)
        {
            Name = name;
            Phone = phone;
            Answer = answer;
        }
    }
}