namespace Easter.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Utilities.Messages;
    using Repositories;
    using Models.Bunnies.Contracts;
    using Models.Bunnies;
    using Models.Dyes.Contracts;
    using Models.Dyes;
    using Models.Eggs.Contracts;
    using Models.Eggs;
    using Easter.Models.Workshops.Contracts;
    using Easter.Models.Workshops;
    using System.Text;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                IBunny bunny = new HappyBunny(bunnyName);

                this.bunnies.Add(bunny);

                return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                IBunny bunny = new SleepyBunny(bunnyName);

                this.bunnies.Add(bunny);

                return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);

            bunny.AddDye(dye);

            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggs.FindByName(eggName);

            List<IBunny> bunnies = this.bunnies.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(t => t.Energy)
                .ToList();

            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IWorkshop workshop = new Workshop();

            foreach (IBunny bunny in bunnies)
            {
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                }
            }

            if (egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone, eggName);
            }

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int countOfColoredEggs = this.eggs.Models.Where(x => x.IsDone()).Count();

            sb.AppendLine($"{countOfColoredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach(IBunny bunny in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(x => !x.IsFinished()).Count()} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
