namespace _03._Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Product
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionClass.ExceptionMsgForName);
                }
                name = value; 
            }
        }
        private int cost;
        public int Cost
        {
            get { return cost; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionClass.ExceptionMsgForMoney);
                }
                cost = value; 
            }
        }

        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}
