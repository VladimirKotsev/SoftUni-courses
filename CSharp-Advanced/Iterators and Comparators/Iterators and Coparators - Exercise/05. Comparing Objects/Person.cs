using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05._Comparing_Objects
{
    public class Person : IComparable<Person>
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string town;
        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }
            if (result == 0)
            {
                result = Town.CompareTo(other.Town);
            }
            return result;
        }
    }
}
