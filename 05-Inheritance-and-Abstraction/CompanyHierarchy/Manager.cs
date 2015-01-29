using System;
using CompanyHierarchy.Interfaces;
using System.Collections.Generic;
using CompanyHierarchy.Enumerations;

namespace CompanyHierarchy
{
    public class Manager : Employee, IManager
    {
        private IList<Employee> employees;

        public Manager(int id, string firstName, string lastName, decimal salary, Department department, IList<Employee> employees) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }

        public IList<Employee> Employees
        {
            get
            {
                return new List<Employee>(this.employees);
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("List of emplyees can not be null or empty.");
                }

                this.employees = value;
            }
        }

        public override string ToString()
        {
            string manager = "Positon: Manager, " + base.ToString() + "\nEmployees to manage: \n";
            foreach (var employee in this.employees)
            {
                manager += "ID: " + employee.Id + ", " + employee.FirstName + " " + employee.LastName + "\n";
            }

            return manager;
        }
    }
}
