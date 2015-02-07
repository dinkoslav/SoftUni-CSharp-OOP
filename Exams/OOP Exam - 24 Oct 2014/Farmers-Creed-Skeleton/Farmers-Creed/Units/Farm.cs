using System.Linq;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using FarmersCreed.Interfaces;
    using System.Text;

    public class Farm : GameObject, IFarm
    {
        private List<Plant> plants = new List<Plant>();
        private List<Animal> animals = new List<Animal>();
        private List<Product> products = new List<Product>();

        public Farm(string id)
            : base(id)
        {
        }

        public List<Plant> Plants
        {
            get { return new List<Plant>(this.plants); }
        }

        public List<Animal> Animals
        {
            get { return new List<Animal>(this.animals); }
        }

        public List<Product> Products
        {
            get { return new List<Product>(this.products); }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void AddPlant(Plant plant)
        {
            this.plants.Add(plant);
        }

        public void AddAnimal(Animal animal)
        {
            this.animals.Add(animal);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();
            bool containsProduct = false;
            for (int i = 0; i < this.Products.Count; i++)
            {
                if (this.Products[i].Id == product.Id)
                {
                    this.Products[i].Quantity += product.Quantity;
                    containsProduct = true;
                }
            }
            if (!containsProduct)
            {
                this.products.Add(product);
            }
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            // TODO: Process all animal and plant behavior
            foreach (var animal in this.Animals)
            {
                animal.Starve();
            }

            foreach (var plant in this.Plants)
            {
                if (!plant.HasGrown)
                {
                    plant.Grow();
                }
                if (plant.HasGrown)
                {
                    plant.Wither();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendLine();
            var sortedAnimals =
                from a in this.Animals
                where a.IsAlive
                orderby a.Id
                select a;
            var sortedPlants =
                from p in this.Plants
                where p.IsAlive
                orderby p.Health, p.Id
                select p;
            var sortedProducts =
                from p in this.Products
                orderby p.ProductType.ToString(), p.Quantity descending , p.Id
                select p;


            foreach (var animal in sortedAnimals)
            {
                result.AppendLine(animal.ToString());
            }
            foreach (var plant in sortedPlants)
            {
                result.AppendLine(plant.ToString());
            }
            foreach (var product in sortedProducts)
            {
                result.AppendLine(product.ToString());
            }
            return result.ToString();
        }
    }
}
