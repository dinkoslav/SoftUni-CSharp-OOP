using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunesShop
{
    public class Media : IMedia
    {
        private string title;
        private decimal price;

        public Media(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get { return this.title; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The title is required.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price must be positive.");
                }

                this.price = value;
            }
        }
    }
}
