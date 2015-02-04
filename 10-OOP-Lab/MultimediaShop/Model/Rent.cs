using MultimediaShop.Enums;
using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.Model
{
    class Rent : IRent
    {
        private Item item;
        private RentStatus rentStatus;
        private decimal rentFine;

        public Rent(Item item, DateTime rentDate, 
            DateTime deadLine)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.DeadLine = deadLine;
            this.RentStatus = RentStatus.Pending;
            this.RentFine = 0;
        }

        public Rent(Item item, DateTime rentDate)
            : this(item, rentDate, rentDate.AddDays(30))
        {
        }

        public Rent(Item item)
            : this(item, DateTime.Now, DateTime.Now.AddDays(30))
        {
        }

        public Item Item
        {
            get { return this.item; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Item can not be empty");
                }
                this.item = value;
            }
        }

        public RentStatus RentStatus {
            get { return CheckRentStatus(); }
            set { this.rentStatus = value; }
        }

        public DateTime RentDate { get; set; }

        public DateTime DeadLine { get; set; }

        public DateTime DateOfReturn { get; set; }

        public decimal RentFine {
            get { return CalculateFine(); }
            set { this.rentFine = value; } 
        }

        public decimal CalculateFine()
        {
            decimal fine = 0;
            int days = (DateTime.Now - this.DeadLine).Days;
            if (days > 0)
            {
                fine = (this.item.Price * 0.01M) * days;
            }

            return fine;
        }

        private RentStatus CheckRentStatus()
        {
            if (this.rentStatus == RentStatus.Returned)
            {
                return RentStatus.Returned;
            }
            else if (DateTime.Now <= this.DeadLine)
            {
                return RentStatus.Pending;
            }
               
            return RentStatus.Overdue;
        }

        public void ReturnItem()
        {
            this.DateOfReturn = DateTime.Now;
            this.rentStatus = RentStatus.Returned;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("- Rent {0}\n", this.RentStatus);
            result.AppendFormat("{0} {1}\n", this.item.GetType().Name, this.item.Id);
            result.AppendFormat("Title: {0}\n", this.item.Title);
            result.AppendFormat("Price: {0}\n", this.item.Price);
            result.AppendFormat("Genres: ");
            foreach (var genre in item.Genres)
            {
                result.AppendFormat("{0} ", genre);
            }

            result.AppendLine();
            if (this.item.GetType().Name == "Book")
            {
                result.AppendFormat("Author: {0}", (this.item as Book).Author);
            }
            if (this.item.GetType().Name == "Video")
            {
                result.AppendFormat("Lenght: {0}", (this.item as Video).Lenght);
            }
            if (this.item.GetType().Name == "Game")
            {
                result.AppendFormat("Age Restriction: {0}", (this.item as Game).AgeRestriction);
            }
            result.AppendLine();
            result.AppendFormat("Rent fine: {0}", this.RentFine);
            return result.ToString();
        }
    }
}
