using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private readonly string name;
        private readonly string registrationNumber;
        private ICollection<IFurniture> furnitures = new List<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            if (ValidateName(name))
            {
                this.name = name;
            }

            if (ValidateRegistrationNumber(registrationNumber))
            {
                this.registrationNumber = registrationNumber;
            }
        }

        public string Name
        {
            get { return this.name; }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(furnitures); }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            IFurniture result = this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
            return result;
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();
            catalog.AppendFormat("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count != 0)
            {
                var sortedFurnitures =
                    from furniture in this.Furnitures
                    orderby furniture.Price, furniture.Model
                    select furniture;

                foreach (var furniture in sortedFurnitures)
                {
                    catalog.AppendFormat("\n" + furniture.ToString());
                }
            }

            return catalog.ToString();
        }

        private bool ValidateRegistrationNumber(string registrationNumberToCheck)
        {
            Regex pattern = new Regex(@"\d{10}");

            if (!pattern.IsMatch(registrationNumberToCheck))
            {
                throw new ArgumentOutOfRangeException("Registration number mustbe 10 diggits long");
            }

            return true;
        }

        private bool ValidateName(string nameToCheck)
        {
            if (string.IsNullOrEmpty(nameToCheck) || nameToCheck.Length < 5)
            {
                throw new ArgumentException("Name can not be null or empty and must be at least 5 symbols");
            }

            return true;
        }
    }
}
