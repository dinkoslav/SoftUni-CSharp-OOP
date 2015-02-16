using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerCatalyst : Catalysts
    {
        const int PowerCatalystPowerEffect = 3;
        const int PowerCatalystHealthEffect = 0;
        const int PowerCatalystAggressionEffect = 0;

        public PowerCatalyst()
            : base(PowerCatalystPowerEffect, PowerCatalystHealthEffect, PowerCatalystAggressionEffect)
        {
        }
    }
}
