namespace PlanetWars.Repositories
{
    using Contracts;
    using Models.MilitaryUnits.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> models;
        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get { return models.AsReadOnly(); }
        }

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(x => x.GetType().Name == name));
        }
    }
}
