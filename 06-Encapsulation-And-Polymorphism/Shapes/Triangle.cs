using System;

public class Triangle : BasicShape
{
    private double secondSide;
    private double thirdSide;

    public Triangle(double width, double height, double secondSide, double thirdSide)
        :base(width, height)
    {
        this.SecondSide = secondSide;
        this.ThirdSide = thirdSide;
    }

    public double ThirdSide
        {
        get { return thirdSide; }
        set { thirdSide = value; }
        }

    public double SecondSide
        {
        get { return secondSide; }
        set { secondSide = value; }
        }

    public override double CalculateArea()
        {
        return ((this.Width * this.Height) / 2);
        }

    public override double CalculatePerimeter()
    {
        return this.Width + this.SecondSide + this.ThirdSide;
    }
    }
