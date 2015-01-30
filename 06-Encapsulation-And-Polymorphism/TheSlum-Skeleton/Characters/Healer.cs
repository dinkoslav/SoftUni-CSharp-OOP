using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;
using TheSlum.Items;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        private const int DefaultHealthPoints = 75;
        private const int DefaultDefensePoints = 50;
        private const int DefaultHealingPoints = 60;
        private const int DefaultRange = 6;

        public Healer(string id, int x, int y, Team team, int healthPoints = DefaultHealthPoints,
            int defensePoints = DefaultDefensePoints, int healingPoints = DefaultHealingPoints,
            int range = DefaultRange)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target =
                from t in targetsList
                where t.Team == this.Team && t != this && t.IsAlive
                orderby t.HealthPoints
                select t;

            return target.FirstOrDefault();
        }

        public override void AddToInventory(Item item)
        {
            Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return base.ToString() + ", Healing: " + this.HealingPoints;
        }
    }
}
