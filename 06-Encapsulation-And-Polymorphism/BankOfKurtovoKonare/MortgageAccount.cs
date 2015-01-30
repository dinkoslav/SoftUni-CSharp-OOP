namespace BankOfKurtovoKonare
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            
        }

        public void Deposit(decimal ammount)
        {
            this.Balance -= ammount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is IndividualCustomer && months > 6)
            {
                return this.Balance * (this.InterestRate / 100) * (months - 6);
            }

            if (this.Customer is IndividualCustomer && months <= 6)
            {
                return 0;
            }

            if (this.Customer is CompanyCustomer && months <= 12)
            {
                return this.Balance * (this.InterestRate / 200) * (months);
            }
            else 
            {
                decimal interest = 0;
                interest += this.Balance * (this.InterestRate / 200) * 12;
                interest += this.Balance * (this.InterestRate / 100) * (months - 12);

                return interest;
            }
        }

        public override string ToString()
        {
            return this.Customer + "Account type: Mortgage\n" +
                "Balance: " + this.Balance + "\n" +
                "Interest rate: " + this.InterestRate + "\n";
        }
    }
}
