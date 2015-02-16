using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HealthCatalyst : Catalysts
    {
        const int HealthCatalystPowerEffect = 0;
        const int HealthCatalystHealthEffect = 3;
        const int HealthCatalystAggressionEffect = 0;

        public HealthCatalyst()
            : base(HealthCatalystPowerEffect, HealthCatalystHealthEffect, HealthCatalystAggressionEffect)
        {
        }
    }
}
