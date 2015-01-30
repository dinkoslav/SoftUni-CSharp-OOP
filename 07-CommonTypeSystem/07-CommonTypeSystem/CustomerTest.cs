using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CommonTypeSystem
    {
    class CustomerTest
        {
        static void Main(string[] args)
            {
            Payment p1 = new Payment("Chair", 150.12M);
            Payment p2 = new Payment("Table", 110M);
            Payment p3 = new Payment("Spoon", 11.11M);
            Payment p4 = new Payment("Fork", 13.99M);
            Payment p5 = new Payment("Lamp", 111.50M);

            IList<Payment> payments1 = new List<Payment> { p1, p2 };
            IList<Payment> payments2 = new List<Payment> { p1, p2, p3, p4, p5 };
            IList<Payment> payments3 = new List<Payment> { p1, p2, p3 };
            IList<Payment> payments4 = new List<Payment> { p1, p2 };
            IList<Payment> payments5 = new List<Payment> { p2, p4, p5 };

            Customer c1 = new Customer("Pesho", "Peshov", "Peshov", 123456, "Home", "9965522987", "mail@a.b", payments1, CustomerType.Golden);
            Customer c2 = new Customer("Pesho", "Peshov", "Peshov", 123456, "Home", "9965522987", "mail@a.b", payments1, CustomerType.Golden);
            Customer c3 = new Customer("Kateto", "Peshova", "Pateto", 1234345, "MyHome", "84946551", "mail@b.a", payments2, CustomerType.Onetime);
            Customer c4 = new Customer("Mincho", "Minchov", "Minchov", 1234253, "Basemend", "1233234", "gmail@a.b", payments4, CustomerType.Diamond);
            Customer c5 = new Customer("Beni", "Benev", "Benev", 12332412, "Trailer", "33334343", "trail@a.b", payments5, CustomerType.Regular);
            Customer c6 = new Customer("Mara", "Pette", "Badjaka", 555555, "Pants", "5555555", "mara@pette.badge", payments3, CustomerType.Diamond);

            Customer c7 = (Customer)c1.Clone();

            //Console.WriteLine(c1 == c2);
            //Console.WriteLine(c1 == c3);
            //Console.WriteLine(c1 != c4);
            //Console.WriteLine(c1 != c2);
            //Console.WriteLine(c1.Equals(c2));
            //Console.WriteLine(c1.Equals(c3));
            //Console.WriteLine(c1.ToString());
            //Console.WriteLine(c1.CompareTo(c2));

            }
        }
    }
