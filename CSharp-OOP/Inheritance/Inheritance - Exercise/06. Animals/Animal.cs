namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Animal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    name = value;
                }
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    gender = value;
                }
            }
        }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name}\n" +
                   $"{this.Name} {this.Age} {this.Gender}\n" +
                   this.ProduceSound();
        }

    }
}
