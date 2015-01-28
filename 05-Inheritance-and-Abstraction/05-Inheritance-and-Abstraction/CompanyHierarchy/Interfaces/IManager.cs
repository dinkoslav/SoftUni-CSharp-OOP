using System.Collections.Generic;

namespace CompanyHierarchy.Interfaces
{
    public interface IManager : IEmployee
    {
        IList<Employee> Employees { get; set; }
    }
}
