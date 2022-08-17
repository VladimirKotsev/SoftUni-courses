namespace SpaceStation.Repositories
{

    using Contracts;
    using Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models;
        public IReadOnlyCollection<IAstronaut> Models
        {
            get { return models.AsReadOnly(); }
        }

        public object Where { get; internal set; }

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return models.Remove(model);
        }
    }
}
