namespace PlanetWars.Repositories
{

    using Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        private readonly List<IWeapon> models;
        public IReadOnlyCollection<IWeapon> Models
        {
            get { return models.AsReadOnly(); }
        }
        public IWeapon FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public bool RemoveItem(string name)
        {
            return this.models.Remove(this.models.FirstOrDefault(x => x.GetType().Name == name));
        }
    }
}
