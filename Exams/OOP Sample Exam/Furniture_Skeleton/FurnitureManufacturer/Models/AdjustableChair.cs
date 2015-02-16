using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (!base.ValidateHeight(height))
            {
                throw new ArgumentOutOfRangeException("Height can not be negarive or 0");
            }

            this.height = height;
        }
    }
}
