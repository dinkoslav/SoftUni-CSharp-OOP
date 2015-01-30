using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDisperser
{
    class StringDisperserTest
    {
        static void Main(string[] args)
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");
            StringDisperser stringDisperser2 = new StringDisperser("gosho", "pesho", "tanio");

            Console.WriteLine(stringDisperser.Equals(stringDisperser2));
            Console.WriteLine(stringDisperser);
            Console.WriteLine(stringDisperser.GetHashCode());
            Console.WriteLine(stringDisperser == stringDisperser2);
            Console.WriteLine(stringDisperser != stringDisperser2);
            StringDisperser stringDisperser3 = (StringDisperser)stringDisperser.Clone();
            Console.WriteLine(stringDisperser3);

            Console.WriteLine(stringDisperser.CompareTo(stringDisperser3));
            //stringDisperser3.AddCharacters("mincho", "pehcno");
            Console.WriteLine(stringDisperser3);
            Console.WriteLine(stringDisperser);
            Console.WriteLine(stringDisperser.CompareTo(stringDisperser3));
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
