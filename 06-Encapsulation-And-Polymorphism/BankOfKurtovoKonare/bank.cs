using System.Collections.Generic;

namespace BankOfKurtovoKonare
{
    public class Bank
    {
        public IList<Account> Accounts { get; set; }

        public Bank(IList<Account> accounts)
        {
            this.Accounts = accounts;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var account in this.Accounts)
            {
                result += account + "\n";
            }

            return result;
        }
    }
}
