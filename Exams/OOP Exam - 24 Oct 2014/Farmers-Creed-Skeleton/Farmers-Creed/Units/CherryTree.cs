using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    public class CherryTree : FoodPlant
    {
        private const int CherryTreeHealth = 14;
        private const int CherryTreeGrowTime = 3;
        private const int CherryTreeProductionQuantity = 4;
        private const int CherryTreeHealthEffect = 2;
        private const ProductType CherryTreeProdType = ProductType.Cherry;

        public CherryTree(string id)
            : base(id, CherryTreeHealth, CherryTreeProductionQuantity, CherryTreeGrowTime, CherryTreeProdType, CherryTreeHealthEffect)
        {
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                return new Food(this.Id + "Product", CherryTreeProdType, FoodType.Organic,  CherryTreeProductionQuantity, CherryTreeHealthEffect);
            }
            else
            {
                throw new ArgumentException("CherryTree is dead!");
            }
        }

        public override void Wither()
        {
            if (this.Health > 0)
            {
                this.Health -= 2;
            }
            if (this.Health <= 0 )
            {
                this.IsAlive = false;
            }
        }
    }
}
