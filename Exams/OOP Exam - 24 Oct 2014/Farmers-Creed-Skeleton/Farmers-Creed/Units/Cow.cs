using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        private const int CowHealth = 15;
        private const int CowProductionQuantity = 6;
        private const int CowHealthEffect = 4;
        private const ProductType CowProductType = ProductType.Milk;
        private const FoodType CowFoodType = FoodType.Organic;

        public Cow(string id)
            : base(id, CowHealth, CowProductionQuantity, CowProductType, CowHealthEffect, CowFoodType)
        {
        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                if (food.FoodType == FoodType.Organic)
                {
                    this.Health += food.HealthEffect*quantity;
                }
                else
                {
                    this.Health -= food.HealthEffect * quantity;
                }
            }
            else
            {
                throw new ArgumentException("Food quantity is not enough!");
            }
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                this.Health -= 2;
                return new Food(this.Id + "Product", CowProductType, CowFoodType, CowProductionQuantity, CowHealthEffect);
            }
            else
            {
                throw new ArgumentException("CherryTree is dead!");
            }
        }

        public override void Starve()
        {
            if (this.Health > 0)
            {
                this.Health -= 1;
            }
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
