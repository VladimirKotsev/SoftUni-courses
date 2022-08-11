namespace CarRacing.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models.Cars;
    using Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public class CarRepository : IRepository<ICar>
    {
        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        private readonly List<ICar> models;
        public IReadOnlyCollection<ICar> Models
        {
            get
            {
                return this.models.AsReadOnly();
            }
        }

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(x => x.VIN == property);
        }

    }
}
