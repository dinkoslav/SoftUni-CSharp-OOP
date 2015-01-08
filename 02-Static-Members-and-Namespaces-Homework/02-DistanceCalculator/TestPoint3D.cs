using System;

namespace _02_DistanceCalculator
{
    class TestPoint3D
    {
        public static void Main()
        {
            Point3D p1 = new Point3D(2.5, 5, 99.9);
            Point3D p2 = new Point3D(42, -5, -12.9);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            double distance = DistanceCalculator.CalcDistance(p1, p2);
            Console.WriteLine(distance);
        }
    }
}