using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightlifeEntertainment
{
    public class AdvancedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string searchPhrase = commandWords[1].ToLower();
            DateTime startTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);

            var performanceSearchResult =
                from performance in base.Performances
                where performance.Name.ToLower().Contains(searchPhrase)
                where performance.StartTime >= startTime
                orderby performance.StartTime, performance.BasePrice descending, performance.Name
                select performance;

            StringBuilder searchResult = new StringBuilder();
            searchResult.AppendFormat("Search for \"{0}\"", commandWords[1]).AppendLine()
                .AppendFormat("Performances:").AppendLine();

            if (performanceSearchResult.Count() == 0)
            {
                searchResult.AppendLine("no results");
            }
            else
            {
                foreach (var performance in performanceSearchResult)
                {
                    searchResult.AppendLine("-" + performance.Name);
                }
            }

            var venueSearchResult =
                from venue in base.Venues
                where venue.Name.ToLower().Contains(searchPhrase)
                orderby venue.Name
                select venue;

            searchResult.AppendLine("Venues:");

            if (venueSearchResult.Count() == 0)
            {
                searchResult.AppendLine("no results");
            }
            else
            {
                foreach (var venue in venueSearchResult)
                {
                    searchResult.AppendLine("-" + venue.Name);
                    var matchingPerformances =
                        from performance in base.Performances
                        where performance.Venue.Equals(venue)
                        where performance.StartTime >= startTime
                        orderby performance.StartTime, performance.BasePrice descending, performance.Name
                        select performance;

                    if (matchingPerformances.Count() != 0)
                    {
                        foreach (var performance in matchingPerformances)
                        {
                            searchResult.AppendLine("--" + performance.Name);
                        }
                    }
                }
            }

            this.Output.Append(searchResult.ToString());
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = GetPerformance(commandWords[1]);
            var soldTickets =
                from ticket in performance.Tickets
                where ticket.Status == TicketStatus.Sold
                select ticket;

            int ticketsCount = soldTickets.Count();
            decimal totalPrice = GetSoldTicketsTotalPrice(soldTickets);

            StringBuilder report = new StringBuilder();
            report.AppendFormat("{0}: {1} ticket(s), total: ${2:0.00}", performance.Name, ticketsCount, totalPrice).AppendLine()
                .AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location).AppendLine()
                .AppendFormat("Start time: {0}", performance.StartTime);

            this.Output.AppendLine(report.ToString());
        }

        private decimal GetSoldTicketsTotalPrice(IEnumerable<ITicket> soldTickets)
        {
            decimal price = 0;
            foreach (var soldTicket in soldTickets)
            {
                price += soldTicket.Price;
            }

            return price;
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);
            int ticketsCount = int.Parse(commandWords[4]);
            if (!this.Venues.Contains(venue) || !this.Performances.Contains(performance))
            {
                throw new ArgumentException("There are not enough available seats or venue/performance name is incorect!");
            }

            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < ticketsCount; i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                case "vip":
                    for (int i = 0; i < ticketsCount; i++)
                    {
                        performance.AddTicket(new VIPTicket(performance));
                    }

                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sport = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sport);
                    break;
                case "concert_hall":
                    var concert = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concert);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "theatre":
                    var theatreVenue = this.GetVenue(commandWords[5]);
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), theatreVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concertVenue = this.GetVenue(commandWords[5]);
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), concertVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }
    }
}
