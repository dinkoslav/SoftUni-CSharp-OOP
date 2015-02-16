using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            Unit unit = GetUnit(commandWords[2]);

            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    unit.AddSupplement(new PowerCatalyst());
                    break;
                case "HealthCatalyst":
                    unit.AddSupplement(new HealthCatalyst());
                    break;
                case "AggressionCatalyst":
                    unit.AddSupplement(new AggressionCatalyst());
                    break;
                case "Weapon":
                    unit.AddSupplement(new Weapon());
                    break;
                default:
                    base.ExecuteAddSupplementCommand(commandWords);
                    break;
            }
        }
    }
}
