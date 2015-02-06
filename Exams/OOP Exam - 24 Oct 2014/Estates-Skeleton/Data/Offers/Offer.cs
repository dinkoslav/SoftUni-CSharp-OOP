using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Data.Offers
{
    public abstract class Offer : IOffer
    {
        public Offer(OfferType offerType)
        {
            this.Type = offerType;
        }

        public OfferType Type { get; set; }

        public IEstate Estate { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Type + ": ");
            result.Append("Estate = " + this.Estate.Name + ", ");
            result.Append("Location = " + this.Estate.Location + ", ");

            return result.ToString();
        }
    }
}
