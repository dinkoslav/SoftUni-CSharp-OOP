using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManager.Models.Recipes
{
    public class Dessert : Meal, IDessert
    {
        private bool withSugar;

        public Dessert(string name, decimal price, int calories, int quantityPerServing, 
            int timeToPrepare, bool isVegan, bool withSugar = true) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.withSugar = withSugar;
        }

        public bool WithSugar
        {
            get { return this.withSugar; }
        }

        public void ToggleSugar()
        {
            this.withSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (!this.WithSugar)
            {
                result.Append("[NO SUGAR] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
