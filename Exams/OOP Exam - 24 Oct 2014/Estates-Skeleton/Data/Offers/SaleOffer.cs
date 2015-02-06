using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Data.Offers
{
    public class SaleOffer : Offer, ISaleOffer
    {
        private decimal price;

        public SaleOffer()
            : base(OfferType.Sale)
        {
            
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Sell price can not be empty!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Append("Price = " + this.Price);
            return result.ToString();
        }
    }
}
