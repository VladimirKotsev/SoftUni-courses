namespace _03._Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionClass.ExceptionMsgForName);
                }
                name = value; 
            }
        }
        private int money;
        public int Money
        {
            get { return money; }
            private set 
            { 
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionClass.ExceptionMsgForMoney);
                }
                money = value; 
            }
        }
        private List<Product> bag;
        public List<Product> Bag
        {
            get { return bag; }
        }

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
    }
}
