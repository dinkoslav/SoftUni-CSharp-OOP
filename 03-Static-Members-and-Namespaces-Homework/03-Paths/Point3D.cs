namespace _03_Paths
{
    class Point3D
    {
        private static readonly Point3D startingPoint = new Point3D(0, 0, 0);

        private double x;
        private double y;
        private double z;

        public static Point3D StartingPoint
        {
            get { return startingPoint; }
        }

        public double X 
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("Point with coordinates: X = {0}, Y = {1}, Z = {2}", this.x, this.y, this.z);
        }
    }
}
