using FarmersCreed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public class Swine : Animal
    {
        private const int SwineHealth = 20;
        private const int SwineProductionQuantity = 1;
        private const int SwineHealthEffect = 5;
        private const ProductType SwineProdType = ProductType.PorkMeat;
        private const FoodType SwineFType = FoodType.Meat;

        public Swine(string id)
            : base(id, SwineHealth, SwineProductionQuantity, SwineProdType, SwineHealthEffect, SwineFType)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                this.Health += (food.HealthEffect * 2) * quantity;
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
                this.IsAlive = false;
                return new Food(this.Id + "Product", SwineProdType, SwineFType, SwineProductionQuantity, SwineHealthEffect);
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
                this.Health -= 3;
            }
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
