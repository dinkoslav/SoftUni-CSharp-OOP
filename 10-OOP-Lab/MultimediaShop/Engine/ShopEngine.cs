using MultimediaShop.Enums;
using MultimediaShop.Interfaces;
using MultimediaShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultimediaShop.Engine
{
    public static class ShopEngine
    {
        private static Dictionary<Item, int> supplies = new Dictionary<Item, int>(); 

        public static void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                ExecuteCommand(input);
            }
        }

        private static void ExecuteCommand(string input)
        {
            string[] splitedInput = input.Split(' ');
            string command = splitedInput[0];
            switch (command)
            {
                case "supply":
                    AddSupplies(splitedInput);
                    break;
                case "sell":
                    SellItem(splitedInput);
                    break;
                case "rent":
                    RentItem(splitedInput);
                    break;
                case "report":
                    if (splitedInput[1] == "sales")
                    {
                        PrintSales(SaleManager.Sales, splitedInput[2]);
                    }
                    else if (splitedInput[1] == "rents")
                    {
                        PrintOverdueRents(RentManager.Rantes);
                    }
                    break;
                default: throw new ArgumentException("Invalid command!");
            }
        }

        private static void PrintSales(ISet<ISale> salesSet, string date)
        {
            DateTime startDate = DateTime.Parse(date);
            var sales =
                (from sale in salesSet
                    where sale.SaleDate >= startDate
                    select sale.Item.Price)
                    .Sum();

            Console.WriteLine(sales);
        }

        private static void PrintOverdueRents(ISet<IRent> rentsSet)
        {
            var rents =
                from rent in rentsSet
                where rent.RentStatus == RentStatus.Overdue
                orderby (rent as Rent).RentFine ascending, rent.Item.Title ascending
                select rent;

            foreach (var rent in rents)
            {
                Console.WriteLine(rent);
            }

        }

        private static void RentItem(string[] splitedInput)
        {
            string id = splitedInput[1];
            DateTime rentDate = DateTime.Parse(splitedInput[2]);
            DateTime deadLine = DateTime.Parse(splitedInput[3]);
            Item key = null;
            foreach (var supply in supplies)
            {
                if (supply.Key.Id == id)
                {
                    if (supply.Value == 0)
                    {
                        throw new Exceptions.InsufficientSuppliesException();
                    }
                    Rent rent = new Rent(supply.Key, rentDate, deadLine);
                    RentManager.AddRent(rent);
                    key = supply.Key;
                }
            }
            if (key != null)
            {
                supplies[key]--;
            }
        }

        private static void SellItem(string[] splitedInput)
        {
            string id = splitedInput[1];
            DateTime sellDate = DateTime.Parse(splitedInput[2]);
            Item key = null;
            foreach (var supply in supplies)
            {
                if (supply.Key.Id == id)
                {
                    if (supply.Value == 0)
                    {
                        throw new Exceptions.InsufficientSuppliesException();
                    }
                    Sale sale = new Sale(supply.Key, sellDate);
                    SaleManager.AddSale(sale);
                    key = supply.Key;
                }
            }
            if (key != null)
            {
                supplies[key]--;
            }
        }

        private static void AddSupplies(string[] splitedInput)
        {
            string item = splitedInput[1];
            int quantity = int.Parse(splitedInput[2]);
            Dictionary<string, string> parameters = ParseParams(splitedInput[3]);
            Item newItem = CreateItem(item, parameters);
            supplies.Add(newItem, quantity);
        }

        private static Item CreateItem(string item, Dictionary<string, string> parameters)
        {
            string id = parameters["id"];
            string title = parameters["title"];
            decimal price = decimal.Parse(parameters["price"]);
            List<string> genre = parameters["genre"].Split(',').ToList();
            for (int i = 0; i < genre.Count; i++)
            {
                genre[i] = genre[i].Trim();
            }

            switch (item.ToLower())
            {
                case "book":
                    return new Book(id, title, price, parameters["author"], genre);
                case "video":
                    return new Video(id, title, price, int.Parse(parameters["length"]), genre);
                case "game":
                    AgeRestriction age = AgeRestriction.Minor;
                    if (parameters["ageRestriction"].ToLower() == "teen")
                    {
                        age = AgeRestriction.Teen;
                    }
                    else if (parameters["ageRestriction"].ToLower() == "adult")
                    {
                        age = AgeRestriction.Adult;
                    }
                    return new Game(id, title, price, genre, age);
                default: throw new NotImplementedException("This item is not implemented!");
            }
        }

        private static Dictionary<string, string> ParseParams(string paramsString)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] pairs = paramsString.Split('&');

            foreach (var pair in pairs)
            {
                string[] keyValuePair = pair.Split('=');
                keyValuePairs[keyValuePair[0]] = keyValuePair[1];
            }

            return keyValuePairs;
        }
    }
}
