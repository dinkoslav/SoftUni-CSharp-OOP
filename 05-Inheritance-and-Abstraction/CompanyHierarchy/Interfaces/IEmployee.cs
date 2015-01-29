using CompanyHierarchy.Enumerations;

namespace CompanyHierarchy.Interfaces
{
    public interface IEmployee : IPerson
    {
        decimal Salary { get; set; }
        Department Department { get; set; }
    }
}
