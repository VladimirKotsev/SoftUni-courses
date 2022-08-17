namespace SpaceStation.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using SpaceStation.Models.Planets.Contracts;

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

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return this.models.Remove(model);
        }
    }
}
