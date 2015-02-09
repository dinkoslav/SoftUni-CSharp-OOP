using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightlifeEntertainment
{
    public class VIPTicket : Ticket
    {
        public VIPTicket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            return base.CalculatePrice() * 1.50m;
        }
    }
}
