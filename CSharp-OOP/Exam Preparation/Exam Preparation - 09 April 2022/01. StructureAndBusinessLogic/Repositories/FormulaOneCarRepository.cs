namespace Formula1.Repositories
{
    using System;

    using Models.Contracts;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;
        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get { return models.AsReadOnly(); }
        }

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return models.Remove(model);
        }
    }
}
