using System;

namespace _03_PCCatalog
{
    class Component
    {
        private string name;
        private string details;
        private decimal? price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Component price must be positive number!");
                }
                this.price = value;
            }
        }

        public Component(string name, decimal? price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public override string ToString()
        {
            return this.Name + ", " + (this.Details != null ? this.Details + ", " : "") + this.Price + " BGN";
        }
    }
}
