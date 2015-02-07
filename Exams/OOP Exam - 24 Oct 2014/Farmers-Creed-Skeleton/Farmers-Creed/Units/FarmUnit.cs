using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;
    using System.Text;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int health;
        private bool isAlive = true;
        private int productionQuantity;
        private int healthEffect;

        protected FarmUnit(string id, int health, int productionQuantity, ProductType productType, int healtEffect)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.ProductType = productType;
            this.healthEffect = healtEffect;
        }

        public int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
        }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public int ProductionQuantity
        {
            get { return this.productionQuantity; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Production quantity can not be negative!");
                }

                this.productionQuantity = value;
            }
        }

        public ProductType ProductType { get; set; }

        public abstract Product GetProduct();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            if (IsAlive)
            {
                result.Append(", Health: " + this.Health);
            }
            else
            {
                result.Append(", DEAD");
            }
            return result.ToString();
        }
    }
}
