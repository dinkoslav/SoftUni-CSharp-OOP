using System;

namespace _01_SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            string input = Console.ReadLine();
            try
            {
                int number = int.Parse(input);
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                double squareRoot = Math.Sqrt(number);
                Console.WriteLine(squareRoot);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number!");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
