using System;

namespace _05_BitArray
{
    public class Test
    {
        private static void Main()
        {
            BitArray bits = new BitArray();

            bits[0] = 1;
            bits[3] = 1;
            bits[8] = 1;
            bits[900] = 0;

            //Console.WriteLine(bits.ConvertBinaryToDecimal());

            for (int i = 0; i < 901; i++)
            {
                Console.Write(bits[i] + " ");
            }
        }
    }
}
