using System;
using System.Linq;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    public class MyEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    PrintCharactersStatus(characterList);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
                default:
                    break;
            }
        }

        protected new void CreateCharacter(string[] inputParams)
        {
            switch (inputParams[1])
            {
                case "warrior":
                    Warrior w = new Warrior(inputParams[2], int.Parse(inputParams[3]), 
                        int.Parse(inputParams[4]), (Team)Enum.Parse(typeof(Team), inputParams[5]));
                    characterList.Add(w);
                    break;
                case "mage":
                    Mage m = new Mage(inputParams[2], int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]), (Team)Enum.Parse(typeof(Team), inputParams[5]));
                    characterList.Add(m);
                    break;
                case "healer":
                    Healer h = new Healer(inputParams[2], int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]), (Team)Enum.Parse(typeof(Team), inputParams[5]));
                    characterList.Add(h);
                    break;
                default:
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            var character = characterList.First(ch => ch.Id == inputParams[1]);
            
            switch (inputParams[2])
            {
                case "axe":
                    Axe axe = new Axe(inputParams[3]);
                    character.AddToInventory(axe);
                    break;
                case "shield":
                    Shield shield = new Shield(inputParams[3]);
                    character.AddToInventory(shield);
                    break;
                case "pill":
                    Pill pill = new Pill(inputParams[3], 0, 0);
                    character.AddToInventory(pill);
                    break;
                case "injection":
                    Injection injection = new Injection(inputParams[3], 0, 0);
                    character.AddToInventory(injection);
                    break;
                default:
                    break;
            }
        }
    }
}
