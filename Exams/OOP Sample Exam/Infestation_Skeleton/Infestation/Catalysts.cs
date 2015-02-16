using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Catalysts : Supplement
    {
        protected Catalysts(int powerEffect, int healthEffect, int aggressionEffect) 
            : base(powerEffect, healthEffect, aggressionEffect)
        {
        }
    }
}
