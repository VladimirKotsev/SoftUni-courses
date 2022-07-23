namespace _07._Military_Elite.Models
{
    using System;
    using Intefaces;
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        private string corps;
        public string Corps
        {
            get
            {
                return corps;
            }
            set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    corps = value;
                }
                else
                {
                    throw new ArgumentException("Invalid corps!");
                }
            }
        }
    }
}
