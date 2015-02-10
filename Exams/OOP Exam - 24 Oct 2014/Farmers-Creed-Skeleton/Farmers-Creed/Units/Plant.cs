namespace FarmersCreed.Units
{
    using System;
    using System.Text;

    public abstract class Plant : FarmUnit
    {
        private bool hasGrown = false;
        private int growTime;

        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get { return this.hasGrown; }
        }

        public int GrowTime
        {
            get { return this.growTime; }
            set
            {
                this.growTime = value;
                if (this.growTime <= 0)
                {
                    this.hasGrown = true;
                }
            }
        }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            this.Health--;
        }

        public virtual void Grow()
        {
            this.GrowTime--;
        }

        public abstract override Product GetProduct();

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
