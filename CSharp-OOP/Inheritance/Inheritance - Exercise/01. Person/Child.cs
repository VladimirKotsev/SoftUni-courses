using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Person
{
    public class Child : Person
    {
        private int age;
        public int Age
        {
            get { return age; }
            set 
            { 
                if (age > -1)
                {
                    age = value;
                }
            }
        }

        public Child(string name, int age) : base (name, age)
        {

        }

    }
}
