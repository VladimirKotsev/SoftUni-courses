namespace Formula1.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public IReadOnlyCollection<IRace> Models
        {
            get { return models.AsReadOnly(); }
        }

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
