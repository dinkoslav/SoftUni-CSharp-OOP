using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManager.Models.Recipes
{
    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private readonly MetricUnit unit;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.unit = unit;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name is required.");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price must be positive.");
                }

                this.price = value;
            }
        }

        public int Calories
        {
            get { return this.calories; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The calories must be positive.");
                }

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get { return this.quantityPerServing; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The quantity per serving must be positive.");
                }

                this.quantityPerServing = value;
            }
        }

        public MetricUnit Unit
        {
            get { return this.unit; }
        }

        public int TimeToPrepare
        {
            get { return this.timeToPrepare; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The time to prepare must be positive.");
                }

                this.timeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine()
                .AppendFormat("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, this.GetUnitString(), this.Calories).AppendLine()
                .AppendFormat("Ready in {0} minutes", this.TimeToPrepare);
            return result.ToString();
        }

        private string GetUnitString()
        {
            switch (this.Unit)
            {
                case MetricUnit.Grams:
                    return "g";
                case MetricUnit.Milliliters:
                    return "ml";
                default:
                    throw new InvalidOperationException("Invalid type of unit selected.");
            }
        }
    }
}
