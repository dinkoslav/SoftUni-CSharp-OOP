using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Model
{
    public class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price,  string author, IList<string> genres) 
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, string genres)
            : this(id, title, price, author, new List<string> { genres }) 
        {
        }

        public string Author
        {
            get { return this.author; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentNullException("Author can not be empty or less then 3 chars!");
                }
                this.author = value;
            }
        }
        
    }
}
