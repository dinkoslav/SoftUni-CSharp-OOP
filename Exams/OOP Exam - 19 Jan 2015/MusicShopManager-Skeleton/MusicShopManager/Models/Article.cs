namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;
    using System;
    using System.Text;

    public class Article : IArticle
    {
        private string make;
        private string model;
        private decimal price;

        public Article(string make, string model, decimal price)
        {
            if (IsValidMake(make))
            {
                this.make = make;
            }

            this.model = model;

            if (IsValidPrice(price))
            {
                this.price = price;
            }
        }

        public string Make
        {
            get { return this.make; }
        }

        public string Model
        {
            get { return this.model; }
        }

        public decimal Price
        {
            get { return this.price; }
        }

        private bool IsValidPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("The price must be positive.");
            }

            return true;
        }

        private bool IsValidMake(string make)
        {
            if (string.IsNullOrEmpty(make))
            {
                throw new ArgumentException("The make is required.");
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder article = new StringBuilder();

            article.AppendFormat("= {0} {1} =", this.Make, this.Model).AppendLine()
                .AppendFormat("Price: ${0:F2}", this.Price);

            return article.ToString();
        }
    }
}
