using System;
using System.Collections.Generic;
using CompanyHierarchy.Enumerations;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy
{
    public class Developer : RegularEmployee, IDeveloper
    {
        private IList<Project> projects;

        public Developer(int id, string firstName, string lastName, decimal salary, Department department, IList<Project> projects) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public IList<Project> Projects
        {
            get
            {
                return new List<Project>(this.projects);
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("List of projects can not be null or empty.");
                }

                this.projects = value;
            }
        }

        public override string ToString()
        {
            string developer = base.ToString() + ", position: Developer\nAssigned projects: \n";
            foreach (var project in this.projects)
            {
                developer += project + "\n";
            }

            return developer;
        }
    }
}
