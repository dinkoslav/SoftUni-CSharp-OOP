using System;

namespace _03_Paths
{
    static class DistanceCalculator
    {
        public static double CalcDistance(Point3D p1, Point3D p2)
        {
            double xDiff = Math.Pow((p1.X - p2.X), 2);
            double yDiff = Math.Pow((p1.Y - p2.Y), 2);
            double zDiff = Math.Pow((p1.Z - p2.Z), 2);

            return Math.Sqrt(xDiff + yDiff + zDiff);
        }
    }
}
