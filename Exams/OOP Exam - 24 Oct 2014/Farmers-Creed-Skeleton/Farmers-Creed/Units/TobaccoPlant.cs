using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
        private const int TobaccoHealth = 12;
        private const ProductType TobaccoProductType = ProductType.Tobacco;
        private const int TobaccoGrowTime = 4;
        private const int TobaccoProductionQuantity = 10;

        public TobaccoPlant(string id)
            : base(id, TobaccoHealth, TobaccoProductionQuantity, TobaccoGrowTime)
        {
        }

        public ProductType ProductType
        {
            get { return TobaccoProductType; }
        }

        public override void Grow()
        {
            this.GrowTime -= 2;
        }

        public override Product GetProduct()
        {
            if (IsAlive && this.HasGrown)
            {
                return new Product(this.Id + "Product", this.ProductType, this.ProductionQuantity);
            }
            else
            {
                throw new ArgumentException("Tobacco is already dead!");
            }
        }
    }
}
