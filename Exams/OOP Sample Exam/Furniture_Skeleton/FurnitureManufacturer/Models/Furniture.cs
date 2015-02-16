using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Furniture : IFurniture
    {
        private readonly string model;
        private readonly string material;
        private decimal price;
        protected decimal height;

        public Furniture(string model, string material, decimal price, decimal height)
        {
            if (ValidateModel(model))
            {
                this.model = model;
            }

            this.material = material;

            this.Price = price;

            if (ValidateHeight(height))
            {
                this.height = height;
            }
        }

        public string Model
        {
            get { return this.model; }
        }

        public string Material
        {
            get { return this.material; }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price can not be negarive or 0");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
        }

        protected bool ValidateHeight(decimal heightToCheck)
        {
            if (heightToCheck <= 0)
            {
                throw new ArgumentOutOfRangeException("Height can not be negarive or 0");
            }

            return true;
        }

        private bool ValidateModel(string modelToCheck)
        {
            if (string.IsNullOrEmpty(modelToCheck) || modelToCheck.Length < 3)
            {
                throw new ArgumentException("Model can not be null or empty and must be at least 3 symbols");
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder furniture = new StringBuilder();
            furniture.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height);

            return furniture.ToString();
        }
    }
}
