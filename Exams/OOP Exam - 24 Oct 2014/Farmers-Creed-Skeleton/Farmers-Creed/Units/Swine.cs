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
        private const ProductType SwineProductType = ProductType.PorkMeat;
        private const FoodType SwineFoodType = FoodType.Meat;
        private const int SwineHealthEffect = 5;
        private const int SwineProductionQuantity = 1;

        public Swine(string id)
            : base(id, SwineHealth, SwineProductionQuantity)
        {
        }

        public ProductType ProductType
        {
            get { return SwineProductType; }
        }

        public FoodType FoodType
        {
            get { return SwineFoodType; }
        }

        public int HealthEffect
        {
            get { return SwineHealthEffect; }
        }

        public override void Starve()
        {
            this.Health -= 3;
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                this.Health += food.HealthEffect * 2 * quantity;
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
                return new Food(this.Id + "Product", this.ProductType, this.FoodType, this.ProductionQuantity,
                    this.HealthEffect);
            }
            else
            {
                throw new ArgumentException("Swine is already dead!");
            }
        }
    }
}
