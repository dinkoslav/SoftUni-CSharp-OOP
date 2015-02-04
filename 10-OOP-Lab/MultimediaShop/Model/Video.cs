using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Model
{
    public class Video : Item
    {
        private int length;

        public Video(string id, string title, decimal price, int length, IList<string> genres) 
            : base(id, title, price, genres)
        {
            this.Lenght = length;
        }

        public Video(string id, string title, decimal price, int lenght, string genres)
            : this(id, title, price, lenght, new List<string> { genres }) 
        {
        }

        public int Lenght
        {
            get { return this.length; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Movie lenght can not be negative!");
                }
                this.length = value;
            }
        }
    }
}
