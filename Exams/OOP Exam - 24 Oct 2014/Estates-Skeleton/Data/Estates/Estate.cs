using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Data.Estates
{
    public abstract class Estate : IEstate
    {
        private string name;
        private double area;
        private string location;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Estate name can not be null or empty!");
                }

                this.name = value;
            }
        }

        public EstateType Type { get; set; }

        public double Area
        {
            get { return this.area; }
            set
            {
                if (value < 0 || 10000 < value)
                {
                    throw new ArgumentOutOfRangeException("Estate area must be in range [0…10000]");
                }
                this.area = value;
            }
        }

        public string Location
        {
            get { return this.location; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Estate location can not be null or empty!");
                }

                this.location = value;
            }
        }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name + ": ");
            result.Append("Name = " + this.Name + ", ");
            result.Append("Area = " + this.Area + ", ");
            result.Append("Location = " + this.Location + ", ");
            result.Append("Furnitured = " + (this.IsFurnished ? "Yes" : "No") + ", ");

            return result.ToString();
        }
    }
}
