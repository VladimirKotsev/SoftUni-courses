namespace _07._Military_Elite.Models
{
    using System;
    using Intefaces;
    using System.Collections.Generic;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        private List<Private> privates;
        public IReadOnlyCollection<Private> Privates
        {
            get
            {
                return privates.AsReadOnly();
            }
        }

        public void AddPrivate(Private toAdd)
        {
            privates.Add(toAdd);
        }

        public override string ToString()
        {
            if (privates.Count == 0)
            {
                return base.ToString() + $"{Environment.NewLine}" +
                   $"Privates:";
            }
            return base.ToString() + $"{Environment.NewLine}" +
                   $"Privates:{Environment.NewLine}"
                   + "  " + String.Join(Environment.NewLine + "  ", this.Privates);
        }
    }
}
