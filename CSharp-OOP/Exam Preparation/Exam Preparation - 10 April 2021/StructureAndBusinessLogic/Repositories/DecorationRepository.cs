namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;
        public IReadOnlyCollection<IDecoration> Models
        {
            get { return models.AsReadOnly(); }
        }

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }
    }
}
