namespace Formula1.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public IReadOnlyCollection<IPilot> Models
        {
            get { return models.AsReadOnly(); }
        }
        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public void Add(IPilot model)
        {
            this.models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return this.models.Remove(model);
        }
    }
}
