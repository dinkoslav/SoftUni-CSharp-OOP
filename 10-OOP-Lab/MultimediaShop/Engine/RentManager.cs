using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Engine
{
    public class RentManager
    {
        private static ISet<IRent> rents = new HashSet<IRent>();

        public static ISet<IRent> Rantes
        {
            get
            {
                return new HashSet<IRent>(rents);
            }
        }
        public static void AddRent(IRent rent)
        {
            rents.Add(rent);
        }
    }
}
