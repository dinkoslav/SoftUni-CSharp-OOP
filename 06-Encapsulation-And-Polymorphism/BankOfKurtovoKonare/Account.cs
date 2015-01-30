using System;

namespace BankOfKurtovoKonare
{
    public abstract class Account
    {
        private decimal balance;
        private decimal interestRate;

        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; set; }

        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance must be positive!");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest must be positive!");
                }

                this.interestRate = value;
            }
        }

        public abstract decimal CalculateInterest(int months);
    }
}
