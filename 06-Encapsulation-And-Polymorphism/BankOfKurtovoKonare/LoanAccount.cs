namespace BankOfKurtovoKonare
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            
        }

        public void Deposit(decimal ammount)
        {
            this.Balance -= ammount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is IndividualCustomer && months > 3)
            {
                return this.Balance * (this.InterestRate / 100) * (months - 3);
            }
            
            if (this.Customer is CompanyCustomer && months > 2)
            {
                return this.Balance * (this.InterestRate / 100) * (months - 2);
            }

            return 0;
        }

        public override string ToString()
        {
            return this.Customer + "Account type: Loan\n" +
                "Balance: " + this.Balance + "\n" +
                "Interest rate: " + this.InterestRate + "\n";
        }
    }
}
