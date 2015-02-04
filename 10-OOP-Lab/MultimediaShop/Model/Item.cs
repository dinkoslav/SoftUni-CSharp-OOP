using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Model
{
    public abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;
        private IList<string> genres = new List<string>();

        protected Item(string id, string title, decimal price, IList<string> genres)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.Genres = genres;
        }

        protected Item(string id, string title, decimal price)
            : this(id, title, price, null)
        {
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 4)
                {
                    throw new ArgumentNullException("Id can not be less the 4 chars or empty!");
                }
                this.id = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title can not be empty!");
                }
                this.title = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price can not be negative!");
                }
                this.price = value;
            }
        }

        public IList<string> Genres
        {
            get { return this.genres; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Genres list can not be null");
                }
                this.genres = value;
            }
        }
    }
}
