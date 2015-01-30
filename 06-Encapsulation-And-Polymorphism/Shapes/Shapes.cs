using System;

namespace Shapes
    {
    class Shapes
        {
        static void Main()
            {
            IShape[] shapes = new IShape[]
            {
            new Triangle(10, 5, 4, 4),
            new Triangle(16, 1, 3, 9),
            new Triangle(18, 10, 12, 20),
            new Rectangle(5, 10),
            new Rectangle(8, 7),
            new Rectangle(2, 2),
            new Circle(5),
            new Circle(10),
            new Circle(7)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape is: " + shape.GetType() + ", area is " + shape.CalculateArea() + ", perimeter is " + shape.CalculatePerimeter());
            }
            }
        }
    }
