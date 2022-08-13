namespace Heroes.Repositories
{
    using System.Linq;

    using Models.Contracts;
    using Contracts;
    using System.Collections.Generic;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;
        public IReadOnlyCollection<IWeapon> Models
        {
            get { return this.weapons.AsReadOnly(); }
        }

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void Add(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return this.weapons.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return this.weapons.Remove(model);
        }
    }
}
