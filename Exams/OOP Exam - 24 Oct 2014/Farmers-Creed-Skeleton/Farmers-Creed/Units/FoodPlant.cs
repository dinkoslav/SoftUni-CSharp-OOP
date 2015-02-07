using FarmersCreed.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public abstract class FoodPlant : Plant
    {
        private const FoodType FType = FoodType.Organic;

        protected FoodPlant(string id, int health, int productionQuantity, int growTime, ProductType productType, int healthEffect)
            : base(id, health, productionQuantity, growTime, productType, healthEffect)
        {
        }

        public FoodType FoodType {
            get { return FType; }
        }

        public override void Wither()
        {
            if (this.Health > 0)
            {
                this.Health -= 2;
            }
            else
            {
                this.IsAlive = false;
            }
        }

        public override void Water()
        {
            this.Health ++;
        }
    }
}
