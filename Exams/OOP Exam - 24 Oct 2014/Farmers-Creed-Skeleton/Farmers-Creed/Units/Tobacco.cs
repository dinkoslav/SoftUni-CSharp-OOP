using FarmersCreed.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
        private const int TobaccoHealth = 12;
        private const int TobaccoGrowTime = 4;
        private const int TobaccoProductionQuantity = 10;
        private const int TobaccoHealthEffect = 0;
        private const ProductType TobaccoProductType = ProductType.Tobacco;

        public TobaccoPlant(string id)
            : base(id, TobaccoHealth, TobaccoProductionQuantity, TobaccoGrowTime, TobaccoProductType, TobaccoHealthEffect)
        {
        }

        public override void Grow()
        {
            if (this.GrowTime > 0)
            {
                this.GrowTime -= 2;
            }
            else
            {
                this.HasGrown = true;
            }
        }

        public override Product GetProduct()
        {
            if (IsAlive && this.HasGrown)
            {
                return new Product(this.Id + "Product", TobaccoProductType, TobaccoProductionQuantity);
            }
            else
            {
                throw new ArgumentException("Tobacco is dead or not grown!");
            }
        }
    }
}
