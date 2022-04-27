using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace Practice6.Models
{
    public class AppCache
    {
        public bool IsEmpty()
        {
            var i = 0;
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.GetCount() == 1 && memoryCache.Get(i.ToString()) == null)
            {
                return true;
            }
            return false;
        }

        public List<Person> GetPeople()
        {
            MemoryCache memoryCache = MemoryCache.Default;
            List<Person> people = new List<Person>();
            var count = memoryCache.GetCount();
            if (count == 0) return null;

            for(int i = 0; i < count; i++)
            {
                people.Add(memoryCache.Get(i.ToString()) as Person);
            }
            return people;
        }

        //TO DO: add,remove,update for cash
        public bool Add(List<Person> people)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            foreach(Person person in people)
            {
                memoryCache.Add(person.Id.ToString(), person, DateTime.Now.AddMinutes(10));
            }
            return true;
        }

        public void Update(Person person)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(person.Id.ToString(), person, DateTime.Now.AddMinutes(10));
        }

        public void Delete()
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Dispose();
        }
    }
}