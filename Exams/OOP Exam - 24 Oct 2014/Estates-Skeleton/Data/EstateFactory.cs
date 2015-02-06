using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new UpdatedEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Estates.Apartment();
                case EstateType.Office:
                    return new Estates.Office();
                case EstateType.House:
                    return new Estates.House();
                case EstateType.Garage:
                    return new Estates.Garage();
                default: 
                    throw new NotSupportedException("Invalid estate type!");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new Offers.RentOffer();
                case OfferType.Sale:
                    return new Offers.SaleOffer();
                default:
                    throw new NotSupportedException("Invalid offer type!");
            }
        }
    }
}
