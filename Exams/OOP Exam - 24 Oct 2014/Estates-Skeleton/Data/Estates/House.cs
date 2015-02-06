using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Data.Estates
{
    public class House : Estate, IHouse
    {
        private int floors;

        public int Floors
        {
            get { return this.floors; }
            set
            {
                if (value < 0 || 10 < value)
                {
                    throw new ArgumentOutOfRangeException("House floors must be in range [0…10]");
                }
                this.floors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Append("Floors: " + this.Floors);

            return result.ToString();
        }
    }
}
