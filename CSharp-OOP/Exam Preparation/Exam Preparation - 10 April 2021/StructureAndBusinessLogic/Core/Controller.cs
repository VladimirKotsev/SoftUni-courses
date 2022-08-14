namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;

    using Repositories;
    using Contracts;
    using Models.Aquariums.Contracts;
    using Utilities.Messages;
    using Models.Aquariums;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Decorations;
    using System.Linq;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Fish;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                IAquarium aquarium = new FreshwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);

                return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);

            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                IAquarium aquarium = new SaltwaterAquarium(aquariumName);
                this.aquariums.Add(aquarium);

                return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                IDecoration decoration = new Ornament();
                this.decorations.Add(decoration);

                return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else if (decorationType == "Plant")
            {
                IDecoration decoration = new Plant();
                this.decorations.Add(decoration);

                return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            if (decoration is null)
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = this.aquariums.First(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);

            this.decorations.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.First(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    IFish fish = new FreshwaterFish(fishName, fishSpecies, price);

                    aquarium.AddFish(fish);

                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }

            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    IFish fish = new SaltwaterFish(fishName, fishSpecies, price);

                    aquarium.AddFish(fish);

                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }

        public string FeedFish(string aquariumName)
        {
            this.aquariums.First(x => x.Name == aquariumName).Feed();

            return String.Format(
                OutputMessages.FishFed, aquariums.First(x => x.Name == aquariumName).Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(x => x.Name == aquariumName);

            decimal sum = 0;

            foreach (var fishPrice in aquarium.Fish)
            {
                sum += fishPrice.Price;
            }

            foreach (var decorationPrice in aquarium.Decorations)
            {
                sum += decorationPrice.Price;
            }

            return String.Format(OutputMessages.AquariumValue, aquarium.Name, sum);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.Append(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
