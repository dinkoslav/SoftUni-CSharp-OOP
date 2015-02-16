using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        private readonly int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height)
        {
            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
        }

        public override string ToString()
        {
            StringBuilder furniture = new StringBuilder(base.ToString());
            furniture.AppendFormat(", Legs: {0}", this.NumberOfLegs);

            return furniture.ToString();
        }
    }
}
