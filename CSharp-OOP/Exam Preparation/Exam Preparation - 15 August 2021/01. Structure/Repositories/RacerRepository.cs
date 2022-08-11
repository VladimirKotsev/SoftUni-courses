namespace CarRacing.Repositories
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Models.Racers;
    using Models.Racers.Contracts;
    using Contracts;
    using Utilities.Messages;

    public class RacerRepository : IRepository<IRacer>
    {
        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        private List<IRacer> models;


        public IReadOnlyCollection<IRacer> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(
                var racer in 
                this.models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(t => t.Username))
            {
                sb.Append(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
