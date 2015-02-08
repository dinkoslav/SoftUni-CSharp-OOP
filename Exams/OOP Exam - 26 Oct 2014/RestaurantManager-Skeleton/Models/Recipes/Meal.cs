using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManager.Models.Recipes
{
    public abstract class Meal : Recipe, IMeal
    {
        private bool isVegan;

        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare)
        {
            this.isVegan = isVegan;
        }

        public bool IsVegan
        {
            get { return this.isVegan; }
        }

        public void ToggleVegan()
        {
            this.isVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.IsVegan)
            {
                result.Append("[VEGAN] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
