namespace _07._Military_Elite.Models
{
    using System;
    using Intefaces;
    using System.Collections.Generic;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repair>();
        }

        private List<Repair> repairs;
        public IReadOnlyCollection<Repair> Repairs
        {
            get
            {
                return repairs.AsReadOnly();
            }
        }

        public void AddRepair(Repair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            if (this.Repairs.Count == 0)
            {
                return base.ToString() + $"{Environment.NewLine}" +
                   $"Corps: {this.Corps}{Environment.NewLine}" +
                   $"Repairs:";
            }
            return base.ToString() + $"{Environment.NewLine}" +
                   $"Corps: {this.Corps}{Environment.NewLine}" +
                   $"Repairs: {Environment.NewLine}"
                   + "  " + String.Join(Environment.NewLine + "  ", this.Repairs);
        }
    }
}
