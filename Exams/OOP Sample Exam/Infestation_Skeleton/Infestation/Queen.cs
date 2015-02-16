using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : Unit
    {
        const int QueenPower = 1;
        const int QueenAggression = 1;
        const int QueenHealth = 30;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, QueenHealth, QueenPower, QueenAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;
            if (this.Id != unit.Id)
            {
                if (unit.UnitClassification.ToString() == "Mechanical" ||
                    unit.UnitClassification.ToString() == "Psionic")
                {
                    attackUnit = true;
                }
            }
            return attackUnit;
        }
    }
}
