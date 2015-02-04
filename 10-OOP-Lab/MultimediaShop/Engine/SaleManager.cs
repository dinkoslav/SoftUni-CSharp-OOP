using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Engine
{
    public static class SaleManager
    {
        private static ISet<ISale> sales = new HashSet<ISale>();

        public static ISet<ISale> Sales
        {
            get
            {
                return new HashSet<ISale>(sales);
            }
        }
        public static void AddSale(ISale sale)
        {
            sales.Add(sale);
        }
    }
}
