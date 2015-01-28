using System.Collections.Generic;

namespace CompanyHierarchy.Interfaces
{
    public interface IDeveloper : IEmployee
    {
        IList<Project> Projects { get; set; } 
    }
}
