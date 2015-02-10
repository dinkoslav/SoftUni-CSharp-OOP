using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public class CherryTree : FoodPlant
    {
        private const int CherryHealth = 14;
        private const ProductType CherryProductType = ProductType.Cherry;
        private const FoodType CherryFoodType = FoodType.Organic;
        private const int CherryHealthEffect = 2;
        private const int CherryProductionQuantity = 4;
        private const int CherryGrowTime = 3;

        public CherryTree(string id)
            : base(id, CherryHealth, CherryProductionQuantity, CherryGrowTime)
        {
        }

        public ProductType ProductType
        {
            get { return CherryProductType; }
        }

        public FoodType FoodType
        {
            get { return CherryFoodType; }
        }

        public int HealthEffect
        {
            get { return CherryHealthEffect; }
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                return new Food(this.Id + "Product", this.ProductType, this.FoodType, this.ProductionQuantity,
                    this.HealthEffect);
            }
            else
            {
                throw new ArgumentException("Cherry tree is already dead!");
            }
        }
    }
}
