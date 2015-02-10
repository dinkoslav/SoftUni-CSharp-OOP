using FarmersCreed.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        private const int CowHealth = 15;
        private const ProductType CowProductType = ProductType.Milk;
        private const FoodType CowFoodType = FoodType.Organic;
        private const int CowHealthEffect = 4;
        private const int CowProductionQuantity = 6;

        public Cow(string id)
            : base(id, CowHealth, CowProductionQuantity)
        {
        }

        public ProductType ProductType
        {
            get { return CowProductType; }
        }

        public FoodType FoodType
        {
            get { return CowFoodType; }
        }

        public int HealthEffect
        {
            get { return CowHealthEffect; }
        }

        public override void Starve()
        {
            this.Health--;
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                if (food.FoodType == FoodType.Organic)
                {
                    this.Health += food.HealthEffect * quantity;
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
                return new Food(this.Id + "Product", this.ProductType, this.FoodType, this.ProductionQuantity,
                    this.HealthEffect);
            }
            else
            {
                throw new ArgumentException("Cow is already dead!");
            }
        }
    }
}
