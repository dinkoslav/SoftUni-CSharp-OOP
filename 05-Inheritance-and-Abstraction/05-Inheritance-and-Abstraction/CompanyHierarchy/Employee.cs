using System;
using CompanyHierarchy.Enumerations;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy
{
    public class Employee : Person, IEmployee
    {
        private decimal salary;

        public Employee(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary can not be negative.");
                }

                this.salary = value;
            }
        }

        public Department Department { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Salary: " + this.salary + ", Department: " + this.Department;
        }
    }
}
