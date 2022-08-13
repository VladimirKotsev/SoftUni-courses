namespace Heroes.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> models;
        public IReadOnlyCollection<IHero> Models
        {
            get { return models.AsReadOnly(); }
        }

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IHero model)
        {
            return this.models.Remove(model);
        }
    }
}
