namespace _07._Military_Elite.Models.Intefaces
{
    using System.Collections.Generic;
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Mission> Missions { get; }
        void CompleteMission();
    }
}
