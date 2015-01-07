using System;

namespace _04_HTMLDispatcher
{
    class Test
    {
        static void Main()
        {
            ElementBuilder li = new ElementBuilder("li");
            li.AddAttribute("class", "nav");
            li.AddAttribute("id", "one");
            li.AddContent("Hello OOP");

            Console.WriteLine(li * 3);
            Console.WriteLine();

            string image = HTMLDispatcher.CreateImage("img.png", "sample img", "sample");
            string url = HTMLDispatcher.CreateURL("https:\\\\softuni.bg", "SoftUni", "SoftUni website");
            string input = HTMLDispatcher.CreateInput("text", "username", "student");

            Console.WriteLine(image);
            Console.WriteLine(url);
            Console.WriteLine(input);
        }
    }
}
