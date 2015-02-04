using MultimediaShop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Model
{
    public class Game : Item
    {

        public Game(string id, string title, decimal price, IList<string> genres, 
            AgeRestriction ageRestriction = AgeRestriction.Minor) 
            : base(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, string genres, 
            AgeRestriction ageRestriction = AgeRestriction.Minor)
            : this(id, title, price, new List<string> { genres }, ageRestriction) 
        {
        }

        public AgeRestriction AgeRestriction { get; set; }
    }
}
