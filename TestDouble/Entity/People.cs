using System;
using System.Linq;
using System.Collections.Generic;

namespace TestDouble.Entity
{
    public class People
    {
        private List<Person> persons;
        
        public People()
        {
            persons = new List<Person>();
        }

        public void addPerson(Person p)
        {
            persons.Add(p);
        }
        public int getNumberOfPerson()
        {
            return persons.Count();
        }
    }
}
