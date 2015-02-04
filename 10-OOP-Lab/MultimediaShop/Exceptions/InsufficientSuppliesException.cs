using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaShop.Exceptions
{
    class InsufficientSuppliesException : ApplicationException
    {
        public InsufficientSuppliesException()
        {
            Console.WriteLine("Insufficient Supplies of the Item!");
        }

        public InsufficientSuppliesException(string message)
            : base(message)
        {
        }

        public InsufficientSuppliesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
