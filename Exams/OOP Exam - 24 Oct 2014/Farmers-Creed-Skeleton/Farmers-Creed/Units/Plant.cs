namespace FarmersCreed.Units
{
    using System;
    using System.Text;

    public abstract class Plant : FarmUnit
    {
        private bool hasGrown = false;
        private int growTime;

        protected Plant(string id, int health, int productionQuantity, int growTime, ProductType productType, int healthEffect)
            : base(id, health, productionQuantity, productType, healthEffect)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get { return this.hasGrown; }
            set { this.hasGrown = value; }
        }

        public int GrowTime
        {
            get { return this.growTime; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Grow time can not be negative");
                }

                this.growTime = value;
            }
        }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            if (this.Health > 0)
            {
                this.Health--;
            }
            else
            {
                this.IsAlive = false;
            }
        }

        public virtual void Grow()
        {
            if (this.GrowTime > 0)
            {
                this.GrowTime--;
            }
            else
            {
                this.hasGrown = true;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            if (IsAlive)
            {
                result.Append(", Grown: " + (this.HasGrown ? "Yes" : "No"));
            }
            return result.ToString();
            
        }
    }
}
