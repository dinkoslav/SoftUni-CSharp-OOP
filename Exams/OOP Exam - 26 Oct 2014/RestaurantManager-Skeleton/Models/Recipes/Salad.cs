using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManager.Models.Recipes
{
    public class Salad : Meal, ISalad
    {
        private readonly bool containsPasta;

        public Salad(string name, decimal price, int calories, int quantityPerServing, 
            int timeToPrepare, bool containsPasta) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, true)
        {
            this.containsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get { return this.containsPasta; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no");
            return result.ToString();
        }
    }
}
