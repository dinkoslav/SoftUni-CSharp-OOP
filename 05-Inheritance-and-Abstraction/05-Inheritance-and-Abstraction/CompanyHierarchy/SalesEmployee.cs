using CompanyHierarchy.Interfaces;
using System.Collections.Generic;
using CompanyHierarchy.Enumerations;
using System;

namespace CompanyHierarchy
{
    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private IList<Sale> sales;

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department, IList<Sale> sales) 
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public IList<Sale> Sales
        {
            get
            {
                return new List<Sale>(this.sales);
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("List of sales can not be null or empty.");
                }

                this.sales = value;
            }
        }

        public override string ToString()
        {
            string salesEmployee = base.ToString() + ", position: Sales employee, " + "\nPerformed sales: \n";
            foreach (var sale in this.sales)
            {
                salesEmployee += sale + "\n";
            }

            return salesEmployee;
        }
    }
}
