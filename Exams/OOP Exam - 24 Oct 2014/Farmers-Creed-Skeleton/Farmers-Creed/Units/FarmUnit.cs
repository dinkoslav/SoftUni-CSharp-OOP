namespace FarmersCreed.Units
{
    using System;
    using System.Text;
    using FarmersCreed.Interfaces;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int health;
        private bool isAlive = true;
        private int productionQuantity;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                if (this.health <= 0)
                {
                    this.isAlive = false;
                }
            }
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
                    throw new ArgumentOutOfRangeException("Production Quantity can not be negative!");
                }
                this.productionQuantity = value;
            }
        }

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
