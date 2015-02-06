using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Data.Offers
{
    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer()
            : base(OfferType.Rent)
        {
            
        }

        public decimal PricePerMonth
        {
            get { return this.pricePerMonth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Rent price per month can not be empty!");
                }
                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.Append("Price = " + this.PricePerMonth);
            return result.ToString();
        }
    }
}
