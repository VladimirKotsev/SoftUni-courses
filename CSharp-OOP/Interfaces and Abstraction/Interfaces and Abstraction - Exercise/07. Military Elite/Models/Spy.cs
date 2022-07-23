namespace _07._Military_Elite.Models
{
    using System;
    using Intefaces;
    public class Spy : Soldier, ISpy
    {
        private int code;

        public Spy(int id, string firstName, string lastName, int code) : base(id, firstName, lastName)
        {
            this.Code = code;
        }

        public int Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}{Environment.NewLine}" +
                   $"Code Number: {this.Code}";
        }
    }
}
