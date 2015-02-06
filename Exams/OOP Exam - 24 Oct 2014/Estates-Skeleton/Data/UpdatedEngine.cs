using System.Linq;
using Estates.Engine;
using Estates.Interfaces;
using Estates.Data.Offers;

namespace Estates.Data
{
    class UpdatedEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByPriceCommand(string minPrice, string maxPrice)
        {
            decimal min = decimal.Parse(minPrice);
            decimal max = decimal.Parse(maxPrice);
            var offers = this.Offers
                .Where(o => o.Type == OfferType.Rent)
                .Where(o => ((RentOffer)o).PricePerMonth >= min && ((RentOffer)o).PricePerMonth <= max)
                .OrderBy(o => ((RentOffer)o).PricePerMonth)
                .ThenBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}