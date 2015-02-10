using FarmersCreed.Interfaces;
using FarmersCreed.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmersCreed.Simulator
{
    public class UpdatedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "add":
                    {
                        this.AddObjectToFarm(inputCommands);
                    }
                    break;
                case "feed":
                {
                    Animal animal = GetAnimalById(inputCommands[1]);
                    Food food = GetProductById(inputCommands[2]) as Food;
                    int quantity = int.Parse(inputCommands[3]);
                    this.farm.Feed(animal,food,quantity);
                }
                    break;
                case "water":
                {
                    Plant plant = GetPlantById(inputCommands[1]);
                    this.farm.Water(plant);
                }
                    break;
                case "exploit":
                {
                    var unit = GetUnitById(inputCommands[1], inputCommands[2]);
                    this.farm.Exploit(unit);
                }
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }    
        }

        private IProductProduceable GetUnitById(string type, string unitId)
        {
            switch (type)
            {
                case "animal":
                    return GetAnimalById(unitId);
                case "plant":
                    return GetPlantById(unitId);
                default:
                    throw new ArgumentException("No such type of unit!");
            }
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    {
                        var plant = new CherryTree(id);
                        (this.farm as Farm).AddPlant(plant);
                    }
                    break;
                case "TobaccoPlant":
                    {
                        var plant = new TobaccoPlant(id);
                        (this.farm as Farm).AddPlant(plant);
                    }
                    break;
                case "Cow":
                    {
                        var animal = new Cow(id);
                        (this.farm as Farm).AddAnimal(animal);
                    }
                    break;
                case "Swine":
                    {
                        var animal = new Swine(id);
                        (this.farm as Farm).AddAnimal(animal);
                    }
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }
    }
}
