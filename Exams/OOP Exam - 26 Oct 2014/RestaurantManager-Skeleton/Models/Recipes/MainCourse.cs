using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManager.Models.Recipes
{
    public class MainCourse : Meal, IMainCourse
    {
        private readonly MainCourseType type;

        public MainCourse(string name, decimal price, int calories, int quantityPerServing,
            int timeToPrepare, bool isVegan, MainCourseType type) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.type = type;
        }

        public MainCourseType Type
        {
            get { return this.type; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Type: {0}", this.Type.ToString());
            return result.ToString();
        }
    }
}
