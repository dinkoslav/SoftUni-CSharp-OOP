using MultimediaShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Interfaces
{
    public interface ISale
    {
        Item Item { get; set; }
        DateTime SaleDate { get; set; }
    }
}
