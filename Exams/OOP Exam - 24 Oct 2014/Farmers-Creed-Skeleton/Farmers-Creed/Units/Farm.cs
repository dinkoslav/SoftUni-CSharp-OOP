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
            get { return new List<Plant>(plants); }
        }

        public List<Animal> Animals
        {
            get { return new List<Animal>(animals); }
        }

        public List<Product> Products
        {
            get { return new List<Product>(products); }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void AddAnimal(Animal animal)
        {
            this.animals.Add(animal);
        }

        public void AddPlant(Plant plant)
        {
            this.plants.Add(plant);
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
                else
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
                from animal in this.Animals
                where animal.IsAlive
                orderby animal.Id
                select animal;

            var sortedPlants =
                from plant in this.Plants
                where plant.IsAlive
                orderby plant.Health, plant.Id
                select plant;

            var sortedProducts =
                from product in this.Products
                orderby product.ProductType.ToString(), product.Quantity descending, product.Id
                select product;

            foreach (var sortedAnimal in sortedAnimals)
            {
                result.AppendLine(sortedAnimal.ToString());
            }

            foreach (var sortedPlant in sortedPlants)
            {
                result.AppendLine(sortedPlant.ToString());
            }

            foreach (var sortedProduct in sortedProducts)
            {
                result.AppendLine(sortedProduct.ToString());
            }

            return result.ToString();

        }
    }
}
