using System;
using System.Linq;
using System.Collections.Generic;

namespace _03_PCCatalog
{
    class PcCatalog
    {
        static void Main()
        {
            Component hdd = new Component("HDD Seagate", 120m, "500GB");
            Component ram = new Component("Ram Corsair", 79m, "8GB");
            Component gpu = new Component("Video card", 134.99m, "Ati Radeon");
            Component motherboard = new Component("Asus P5K-VM", 99.45m);
            Component monitor = new Component("Philips", 233.34m, "100 inch");
            Component processor = new Component("Intel i5", 320m, "3Ghz");

            List<Component> components1 = new List<Component>()
            {
                hdd, ram, gpu, motherboard, monitor, processor
            };

            List<Component> components2 = new List<Component>()
            {
                hdd, gpu, motherboard, processor
            };

            List<Component> components3 = new List<Component>()
            {
                ram, gpu, monitor, processor
            };

            Computer pc1 = new Computer("Lenovo", components1);
            Computer pc2 = new Computer("Asus", components2);
            Computer pc3 = new Computer("Sony", components3);

            List<Computer> computers = new List<Computer>()
            {
                pc1, pc2, pc3
            };

            List<Computer> sortedComputers = computers.OrderBy(computer => computer.Price).ToList();

            foreach (Computer sortedComputer in sortedComputers)
            {
                sortedComputer.PrintConfiguration();
                Console.WriteLine();
            }
        }
    }
}