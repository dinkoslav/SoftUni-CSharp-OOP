using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Data.Estates
{
    public class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public int Width
        {
            get { return this.width; }
            set
            {
                if (value < 0 || 500 < value)
                {
                    throw new ArgumentOutOfRangeException("Garage width must be in range [0…500]");
                }
                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                if (value < 0 || 500 < value)
                {
                    throw new ArgumentOutOfRangeException("Garage height must be in range [0…500]");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Append("Width: " + this.Width + ", ");
            result.Append("Height: " + this.Height);

            return result.ToString();
        }
    }
}
