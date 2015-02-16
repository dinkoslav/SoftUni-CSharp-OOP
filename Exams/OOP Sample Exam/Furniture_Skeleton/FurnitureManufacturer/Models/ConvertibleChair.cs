using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private readonly decimal initialHeight;
        private bool isConverted;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.isConverted = false;
            this.initialHeight = height;
        }

        public bool IsConverted
        {
            get { return this.isConverted; }
        }

        public void Convert()
        {
            if (!IsConverted)
            {
                this.height = 0.10m;
            }
            else
            {
                this.height = this.initialHeight;
            }

            this.isConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            StringBuilder furniture = new StringBuilder(base.ToString());
            furniture.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");

            return furniture.ToString();
        }
    }
}
