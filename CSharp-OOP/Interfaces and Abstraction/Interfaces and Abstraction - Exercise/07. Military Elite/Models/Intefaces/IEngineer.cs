namespace _07._Military_Elite.Models.Intefaces
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Repair> Repairs { get; }
    }
}
