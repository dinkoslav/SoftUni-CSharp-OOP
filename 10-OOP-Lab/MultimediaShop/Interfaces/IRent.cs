using MultimediaShop.Enums;
using MultimediaShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Interfaces
{
    public interface IRent
    {
        Item Item { get; set; }
        RentStatus RentStatus { get; set; }
        DateTime RentDate { get; set; }
        DateTime DeadLine { get; set; }
        DateTime DateOfReturn { get; set; }

        decimal CalculateFine();
    }
}
