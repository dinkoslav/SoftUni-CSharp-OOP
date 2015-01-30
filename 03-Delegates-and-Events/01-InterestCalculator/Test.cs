using System;

public class Test
{
    public static string GetSimpleInterest(decimal sum, decimal interest, int years)
    {
        decimal result = sum * (1 + (interest / 100) * years);
        return result.ToString("F4");
    }

    public static string GetCompoundInterest(decimal sum, decimal interest, int years)
    {
        decimal result = sum * (decimal)Math.Pow((double)(1 + (interest / 100) / 12), years * 12);
        return result.ToString("F4");
    }

    static void Main()
    {
        //with delegate:
        CalculateInterest calcSimpleInterst = GetSimpleInterest;
        CalculateInterest calcCompoundInterst = GetCompoundInterest;
        InterestCalculator firstExample = new InterestCalculator(500m, 5.6m, 10, calcCompoundInterst);
        InterestCalculator secondExample = new InterestCalculator(2500m, 7.2m, 15, calcSimpleInterst);

        Console.WriteLine(firstExample.EarnedInterest);
        Console.WriteLine(secondExample.EarnedInterest);

        //with Func<T1, T2, TResult>:
        Func<decimal, decimal, int, string> simpleInterest = GetSimpleInterest;
        Func<decimal, decimal, int, string> compundInterest = GetCompoundInterest;
        InterestCalculator thirdExample = new InterestCalculator(500m, 5.6m, 10, compundInterest);
        InterestCalculator fourthExample = new InterestCalculator(2500m, 7.2m, 15, simpleInterest);

        Console.WriteLine(thirdExample.EarnedInterest);
        Console.WriteLine(fourthExample.EarnedInterest);
    }
}