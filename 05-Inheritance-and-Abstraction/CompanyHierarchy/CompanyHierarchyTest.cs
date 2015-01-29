using System;
using System.Collections.Generic;
using CompanyHierarchy.Enumerations;

namespace CompanyHierarchy
{
    public class CompanyHierarchyTest
    {
        static void Main()
        {
            List<Sale> sales1 = new List<Sale>
            {
                new Sale("Coffee", new DateTime(2014, 12, 2), 5.34m),
                new Sale("Tea", new DateTime(2015, 1, 13), 2.28m),
                new Sale("Beer", new DateTime(2014, 10, 25), 3.79m)
            };
            List<Sale> sales2 = new List<Sale>
            {
                new Sale("Cheese", new DateTime(2013, 6, 28), 9.99m),
                new Sale("Melon", new DateTime(2014, 3, 3), 4.00m),
                new Sale("Cucumber", new DateTime(2015, 1, 5), 7.77m)
            };

            List<Project> projects1 = new List<Project>
            {
                new Project("WebApp", new DateTime(2014, 10, 5), "Web store", State.Open),
                new Project("DesktopApp", new DateTime(2013, 5, 30), "Torrent client", State.Closed),
                new Project("DesktopApp", new DateTime(2012, 1, 31), "OS", State.Open),
            };
            List<Project> projects2 = new List<Project>
            {
                new Project("WindowsMobileApp", new DateTime(2013, 7, 13), "Skype", State.Closed),
                new Project("iOSApp", new DateTime(2014, 11, 11), "iTunes", State.Open),
                new Project("AndroidApp", new DateTime(2015, 1, 15), "Play Store", State.Open),
            };

            SalesEmployee gosho = new SalesEmployee(3333, "Georgi", "Petrov", 780.50m, Department.Sales, sales1);
            SalesEmployee pesho = new SalesEmployee(4444, "Petar", "Mihajlov", 1100.90m, Department.Sales, sales2);
            Developer mimi = new Developer(5555, "Mariq", "Dimitrova", 1500m, Department.Production, projects1);
            Developer sisi = new Developer(6666, "Silviya", "Zarkova", 1499.99m, Department.Production, projects2);

            Manager mitko = new Manager(1111, "Dimitar", "Peshev", 2345.67m, Department.Sales, new List<Employee>{ gosho, pesho });
            Manager gencho = new Manager(1111, "Gencho", "Yankov", 3456.78m, Department.Production, new List<Employee> { mimi, sisi });

            List<Employee> employees = new List<Employee>{mitko, gencho, gosho, pesho, mimi, sisi};

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
                Console.WriteLine();
            }
        }
    }
}
