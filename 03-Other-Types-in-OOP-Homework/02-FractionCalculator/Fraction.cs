using System;
using System.Numerics;

public struct Fraction
{
    private BigInteger numerator;
    private BigInteger denominator;

    public Fraction(BigInteger numerator, BigInteger denominator)
        : this()
    {
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public BigInteger Numerator
    {
        get { return this.numerator; }
        set
        {
            if (value < -9223372036854775808 || value > 9223372036854775807)
            {
                Console.WriteLine("Numerator must be in range [-9223372036854775808…9223372036854775807]");
                throw new ArgumentOutOfRangeException();
            }
            this.numerator = value;
        }
    }

    public BigInteger Denominator
    {
        get { return this.denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denominator can not be zero!");
            }
            if (value < -9223372036854775808 || value > 9223372036854775807)
            {
                Console.WriteLine("Denominator must be in range [-9223372036854775808…9223372036854775807]");
                throw new ArgumentOutOfRangeException();
            }

            this.denominator = value;
        }
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        if (f1.denominator == f2.denominator)
        {
            BigInteger numerator = f1.numerator + f2.numerator;
            return new Fraction { numerator = numerator, denominator = f1.denominator };
        }

        BigInteger newDenominator = f1.denominator * f2.denominator;
        BigInteger numeratorOne = f1.numerator * f2.denominator;
        BigInteger numeratorTwo = f2.numerator * f1.denominator;
        BigInteger newNumerator = numeratorOne + numeratorTwo;

        return new Fraction { numerator = newNumerator, denominator = newDenominator };
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        if (f1.denominator == f2.denominator)
        {
            BigInteger numerator = f1.numerator - f2.numerator;
            return new Fraction { numerator = numerator, denominator = f1.denominator };
        }

        BigInteger newDenominator = f1.denominator * f2.denominator;
        BigInteger numeratorOne = f1.numerator * f2.denominator;
        BigInteger numeratorTwo = f2.numerator * f1.denominator;
        BigInteger newNumerator = numeratorOne - numeratorTwo;

        return new Fraction { numerator = newNumerator, denominator = newDenominator };
    }

    public override string ToString()
    {
        return ((decimal)this.numerator / (decimal)this.denominator).ToString();
    }
}
