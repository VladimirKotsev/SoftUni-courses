namespace PlanetWars.Repositories
{
    using Contracts;
    using Models.Planets.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models
        {
            get { return models.AsReadOnly(); }
        }

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(x => x.Name == name));
        }
    }
}
