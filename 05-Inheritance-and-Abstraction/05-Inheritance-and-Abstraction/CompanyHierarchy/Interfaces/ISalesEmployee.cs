using System.Collections.Generic;

namespace CompanyHierarchy.Interfaces
{
    public interface ISalesEmployee : IEmployee
    {
        IList<Sale> Sales { get; set; }
    }
}
