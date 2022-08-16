namespace Easter.Repositories
{

    using Contracts;
    using Models.Eggs;
    using Models.Eggs.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models;
        public IReadOnlyCollection<IEgg> Models
        {
            get { return models.AsReadOnly(); }
        }

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public void Add(IEgg model)
        {
            this.models.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IEgg model)
        {
            return this.models.Remove(model);
        }
    }
}
