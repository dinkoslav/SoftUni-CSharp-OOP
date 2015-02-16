using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AggressionCatalyst : Catalysts
    {
        const int AggressionCatalystPowerEffect = 0;
        const int AggressionCatalystHealthEffect = 0;
        const int AggressionCatalystAggressionEffect = 3;

        public AggressionCatalyst()
            : base(AggressionCatalystPowerEffect, AggressionCatalystHealthEffect, AggressionCatalystAggressionEffect)
        {
        }
    }
}
