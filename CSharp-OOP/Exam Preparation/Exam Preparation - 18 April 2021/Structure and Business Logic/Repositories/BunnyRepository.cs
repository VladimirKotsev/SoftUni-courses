namespace Easter.Repositories
{
    using System.Linq;

    using Models.Bunnies.Contracts;
    using System.Collections.Generic;
    using Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models;

        public IReadOnlyCollection<IBunny> Models
        {
            get { return models.AsReadOnly(); }
        }

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public void Add(IBunny model)
        {
            this.models.Add(model);
        }

        public IBunny FindByName(string name)
        {
            return this.Models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IBunny model)
        {
            return this.models.Remove(model);
        }
    }
}
