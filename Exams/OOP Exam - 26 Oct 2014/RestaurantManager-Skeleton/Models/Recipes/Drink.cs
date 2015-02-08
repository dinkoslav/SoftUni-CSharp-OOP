using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManager.Models.Recipes
{
    public class Drink : Recipe, IDrink
    {
        private readonly bool isCarbonated;

        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare)
        {
            this.isCarbonated = isCarbonated;
            ValidateCalories(calories);
            ValidateTimeToPrepare(timeToPrepare);
        }

        public bool IsCarbonated
        {
            get { return this.isCarbonated; }
        }

        private void ValidateTimeToPrepare(int time)
        {
            if (time > 20)
            {
                throw new ArgumentException("The time to prepare a drink must not be greater than 20 minutes.");
            }
        }

        private void ValidateCalories(int calories)
        {
            if (calories > 100)
            {
                throw new ArgumentException("The calories in a drink must not be greater than 100.");
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Carbonated: {0}", this.IsCarbonated ? "yes" : "no");
            return result.ToString();
        }
    }
}
