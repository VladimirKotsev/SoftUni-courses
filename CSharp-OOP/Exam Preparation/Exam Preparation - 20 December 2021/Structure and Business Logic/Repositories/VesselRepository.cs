namespace NavalVessels.Repositories
{
    using System;

    using Contracts;
    using Models.Contracts;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> models;
        public IReadOnlyCollection<IVessel> Models
        {
            get { return models.AsReadOnly(); }
        }

        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }

        public void Add(IVessel model)
        {
            this.models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            return this.models.Remove(model);
        }
    }
}
