using System;
using System.Numerics;

namespace _05_BitArray
{
    class BitArray
    {
        public const int BitCounts = 100000;
        private BigInteger bitValues;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= BitCounts)
                {
                    throw new IndexOutOfRangeException("Index must be between 0 and 100000!");
                }

                if ((bitValues & (1 << index)) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            set
            {
                if (index < 0 || index >= BitCounts)
                {
                    throw new IndexOutOfRangeException("Index must be between 0 and 100000!");
                }
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Value must be 0 or 1!");
                }

                bitValues &= ~((BigInteger)(1 << index));
                bitValues |= (BigInteger)(value << index);
            }
        }

        public BigInteger ConvertBinaryToDecimal()
        {
            BigInteger decimalNum = 0;
            int position = 0;

            for (int i = BitCounts - 1; i >= 0; i--)
            {
                int bit = this[position];
                decimalNum += (BigInteger)(this[position] * Math.Pow(2, position));
                position++;
            }
            Console.WriteLine(bitValues);
            return decimalNum;
        }

        public override string ToString()
        {
            return bitValues.ToString();    
        }
    }
}
