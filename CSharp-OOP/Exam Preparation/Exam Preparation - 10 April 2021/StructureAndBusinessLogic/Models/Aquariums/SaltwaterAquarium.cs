﻿namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int capacitySaltwaterAquarium = 25;
        public SaltwaterAquarium(string name) : base(name, capacitySaltwaterAquarium)
        {

        }
    }
}