namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Person
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length >= 3)
                { firstName = value; }
                else
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length >= 3)
                { lastName = value; }
                else
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
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
                { age = value; }
                else
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
            }
        }
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (salary >= 460)
                { salary = value; }
                else
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
            }
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        //public void IncreaseSalary(decimal percentage)
        //{
        //    if (this.Age > 30)
        //        this.Salary += this.Salary * percentage / 100;
        //    else
        //        this.Salary += this.Salary * percentage / 200;


        //}
        //public override string ToString()
        //{
        //    return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        //}
    }
}

