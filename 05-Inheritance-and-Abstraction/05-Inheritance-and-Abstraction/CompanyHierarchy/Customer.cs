using System;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy
{
    class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;

        public Customer(int id, string firstName, string lastName, decimal netPurchaseAmount) 
            : base(id, firstName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get
            {
                return this.netPurchaseAmount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Net purchase amount can not be negative.");
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", Net purchase amount: " + this.netPurchaseAmount;
        }
    }
}
