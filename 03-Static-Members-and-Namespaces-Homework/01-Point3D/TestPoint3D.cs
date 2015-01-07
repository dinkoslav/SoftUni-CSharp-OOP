using System;

namespace _01_Point3D
{
    class TestPoint3D
    {
        public static void Main()
        {
            Point3D p1 = new Point3D(2.5, 5, 99.9);
            Point3D zeroPoint = Point3D.StartingPoint;

            Console.WriteLine(p1);
            Console.WriteLine(zeroPoint);
        }
    }
}