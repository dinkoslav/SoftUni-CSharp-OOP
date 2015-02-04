using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Interfaces
{
    public interface IItem
    {
        string Id { get; set; }
        string Title { get; set; }
        decimal Price { get; set; }
        IList<string> Genres { get; set; }

    }
}
