namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Product : GameObject, IProduct
    {
        private int quantity;
        private ProductType productType;

        public Product(string id, ProductType productType, int quantity)
            : base(id)
        {
            this.Quantity = quantity;
            this.ProductType = productType;
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product quantity cannot be negative!");
                }
                this.quantity = value;
            }
        }

        public ProductType ProductType
        {
            get { return this.productType; }
            set { this.productType = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Append(", Quantity: " + this.Quantity);
            result.Append(", Product Type: " + this.ProductType);
            return result.ToString();
        }
    }
}
