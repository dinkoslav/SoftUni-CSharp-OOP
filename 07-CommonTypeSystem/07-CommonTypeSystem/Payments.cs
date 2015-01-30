using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CommonTypeSystem
    {
    public class Payment : IComparable<Payment>
        {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
            {
            this.ProductName = productName;
            this.Price = price;
            }

        public decimal Price
            {
            get { return this.price; }
            set
                {
                if (value < 0)
                    {
                    throw new ArgumentOutOfRangeException("Price can not be negative");
                    }
                this.price = value;
                }
            }

        public string ProductName
            {
            get { return this.productName; }
            set
                {
                if (string.IsNullOrEmpty(value))
                    {
                    throw new ArgumentNullException("Product name can not be empty");
                    }
                this.productName = value;
                }
            }


        public int CompareTo(Payment other)
            {
            if (!this.ProductName.Equals(other.ProductName))
                {
                return String.Compare(this.ProductName, other.ProductName, true, CultureInfo.CurrentCulture);
                }
            if (this.Price > other.Price)
                {
                return 1;
                }
            if (this.Price < other.Price)
                {
                return -1;
                }
            return 0;
            }

        public override string ToString()
            {
            return "P name: " + this.productName + ", price: " + this.price;
            }
        }
    }
