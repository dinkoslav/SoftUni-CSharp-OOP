using System;

public class InterestCalculator
{
    private decimal sum;
    private decimal interest;
    private int years;
    private string earnedInterest;

    //constructor with delegate
    public InterestCalculator(decimal sum, decimal interest, int years, CalculateInterest calcMethod)
    {
        this.Sum = sum;
        this.Interest = interest;
        this.Years = years;
        this.earnedInterest = calcMethod(this.sum, this.interest, this.years);
    }

    //constructor with Func<>
    public InterestCalculator(decimal sum, decimal interest, int years, 
        Func<decimal, decimal, int, string> calcMethod)
    {
        this.Sum = sum;
        this.Interest = interest;
        this.Years = years;
        this.earnedInterest = calcMethod(this.sum, this.interest, this.years);
    }

    public decimal Sum
    {
        get { return this.sum; }
        set
        {
            ValidateNumber(value);
            this.sum = value;
        }
    }

    public decimal Interest
    {
        get { return this.interest; }
        set
        {
            ValidateNumber(value);
            this.interest = value;
        }
    }

    public int Years
    {
        get { return this.years; }
        set
        {
            ValidateNumber(value);
            this.years = value;
        }
    }

    public string EarnedInterest
    {
        get { return this.earnedInterest; }
    }

    private void ValidateNumber(decimal number)
    {
        if (number <= 0)
        {
            Console.WriteLine("Parameters can not be 0 or negative!");
            throw new ArgumentNullException();
        }
    }
}
