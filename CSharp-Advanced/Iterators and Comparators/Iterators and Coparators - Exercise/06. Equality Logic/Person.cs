using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06._Equality_Logic
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
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int CompareTo( Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }
            return result;
        }
        public override int GetHashCode() => Name.GetHashCode() ^ Age.GetHashCode();
        public override bool Equals(object? obj)
        {
            var other = obj as Person;
            if (other == null)
            {
                return false;
            }
            return Age == other.Age && Name == other.Name;
        }
        
    }
}
