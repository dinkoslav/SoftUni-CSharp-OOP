using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.Model
{
    public class Sale : ISale
    {
        private Item item;

        public Sale(Item item, DateTime saleDate)
        {
            this.Item = item;
            this.SaleDate = saleDate;
        }

        public Sale(Item item)
            : this(item, DateTime.Now)
        {
            this.Item = item;
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

        public DateTime SaleDate { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("- Sale {0}\n", this.SaleDate);
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
            return result.ToString();
        }
    }
}
