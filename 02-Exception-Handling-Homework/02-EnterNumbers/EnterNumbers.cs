using System;

namespace _02_EnterNumbers
{
    class EnterNumbers
    {
        static void Main()
        {
            int start = 1;
            int end = 100;
            int[] numbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                bool validNumber = false;
                do
                {
                    try
                    {
                        int tempNumber = ReadNumber(start, end);
                        if (i > 0 && tempNumber <= numbers[i - 1])
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        numbers[i] = tempNumber;
                        validNumber = true;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Number must be greater than {0}", numbers[i - 1]);
                    }
                } while (!validNumber);
            }

            printNumbers(numbers);
        }

        private static void printNumbers(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }

        public static int ReadNumber(int start, int end)
        {
            while (true)
            {
                Console.Write("Enter integer number: ");
                string input = Console.ReadLine();
                try
                {
                    int num = int.Parse(input);
                    if (num < start || num > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    return num;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered invalid number!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number must be between {0} and {1}", start, end);
                }
            }
        }
    }
}