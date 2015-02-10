using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public abstract class FoodPlant : Plant
    {
        protected FoodPlant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity, growTime)
        {
        }

        public override void Water()
        {
            this.Health++;
        }

        public override void Wither()
        {
            this.Health -= 2;
        }

        public abstract override Product GetProduct();
    }
}
