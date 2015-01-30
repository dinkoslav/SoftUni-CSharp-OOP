namespace BankOfKurtovoKonare
{
    public class DepositAccount : Account, IDepositable, IWithDrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            
        }

        public void Deposit(decimal ammount)
        {
            this.Balance += ammount;
        }

        public void WithDraw(decimal ammount)
        {
            this.Balance -= ammount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance >= 1000)
            {

                return this.Balance * (this.InterestRate / 100) * months;
            }

            return 0;
        }

        public override string ToString()
        {
            return this.Customer + "Account type: Deposit\n" + 
                "Balance: " + this.Balance + "\n" +
                "Interest rate: " + this.InterestRate + "\n";
        }
    }
}
