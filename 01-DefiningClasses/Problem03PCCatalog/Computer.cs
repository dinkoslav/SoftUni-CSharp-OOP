using System;
using System.Collections.Generic;

namespace _03_PCCatalog
{
    class Computer
    {
        private string name;
        private List<Component> components;
        private decimal? price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name", "Name can not be empty!");
                }
                this.name = value;
            }
        }
        public decimal? Price { get; set; }

        public Computer(string name, List<Component> components )
        {
            this.Name = name;
            this.components = components;
            this.Price = calculatePrice(this.components);
        }

        private decimal? calculatePrice(List<Component> comps)
        {
            decimal? totalPrice = 0m;
            foreach (Component comp in comps)
            {
                totalPrice += comp.Price;
            }

            return totalPrice;
        }

        public void PrintConfiguration()
        {
            string configuration = "PC name: " + this.Name + "\n";
            foreach (Component component in this.components)
            {
                configuration += component.ToString() + "\n";
            }
            configuration += "Total Price: " + this.Price;
            Console.WriteLine(configuration);
        }
    }
}