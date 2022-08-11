namespace Gym.Repositories
{
    using System;
    using System.Linq;

    using Contracts;
    using Models.Equipment.Contracts;
    using System.Collections.Generic;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;
        public IReadOnlyCollection<IEquipment> Models
        {
            get { return models.AsReadOnly(); }
        }

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }

        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }
    }
}
