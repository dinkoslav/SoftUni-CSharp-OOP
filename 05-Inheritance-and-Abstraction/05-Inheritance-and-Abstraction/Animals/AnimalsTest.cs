using System;
using System.Linq;

namespace Animals
{
    class AnimalsTest
    {
        static void Main()
        {
            Animal[] animals =
            {
                new Dog("Sharo", 2, "male"),
                new Dog("Rex", 5, "male"),
                new Dog("Liza", 1, "female"),
                new Frog("Jaba Zelena otrovnica", 3, "female"), 
                new Frog("Chervena jaba", 15, "male"), 
                new Frog("Kavakashta jaba", 7, "female"),
                new Kitten("Masha", 4),
                new Tomcat("Tom", 8),
                new Tomcat("Tomcho", 2),
                new Kitten("Kitty", 1) 
            };

            var cats =
                from animal in animals
                where animal is Cat
                select animal;

            Console.WriteLine("Average cats age is: {0:F2}", ((double)cats.Sum(c => c.Age) / cats.Count()));

            var dogs =
                from animal in animals
                where animal is Dog
                select animal;

            Console.WriteLine("Average dogs age is: {0:F2}", ((double)dogs.Sum(d => d.Age) / dogs.Count()));

            var frogs =
                from animal in animals
                where animal is Frog
                select animal;

            Console.WriteLine("Average cats age is: {0:F2}", ((double)frogs.Sum(f => f.Age) / frogs.Count()));
        }
    }
}
