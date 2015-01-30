using System;
using System.Collections.Generic;

namespace BankOfKurtovoKonare
{
    public class Test
    {
        public static void Main()
        {
            IndividualCustomer pesho = new IndividualCustomer("Petar", "Petrov", 8003157897, 
                "Sofia, bul.Tcarigradsko shose 15", "02-35498765");
            IndividualCustomer mimi = new IndividualCustomer("Maria", "Nikolova", 8607285348,
                "Sofia, bul.Vitoshka 35", "0877-563248");
            CompanyCustomer softUni = new CompanyCustomer("Software University Ltd.", 103587986,
                "Sofia, bul.NqkoiSi 9", "02-6666666");
            CompanyCustomer hardUni = new CompanyCustomer("Hardware University Ltd.", 103986444,
                "Sofia, bul.EdiKoiSi 6", "02-4444444");

            DepositAccount d1 = new DepositAccount(pesho, 1000, 0.1m);
            DepositAccount d2 = new DepositAccount(softUni, 50000, 0.15m);
            LoanAccount l1 = new LoanAccount(mimi, 5500, 0.2m);
            LoanAccount l2 = new LoanAccount(hardUni, 90000, 0.18m);
            MortgageAccount m1 = new MortgageAccount(pesho, 60000, 0.12m);
            MortgageAccount m2 = new MortgageAccount(hardUni, 160000, 0.1m);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Deposits and withdraws:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Old balance " + d1.Balance + ", new balance: ");
            d1.Deposit(500);
            Console.WriteLine(d1.Balance);
            Console.Write("Old balance " + d2.Balance + ", new balance: ");
            d2.WithDraw(12500.50m);
            Console.WriteLine(d2.Balance);
            Console.Write("Old balance " + l1.Balance + ", new balance: ");
            l1.Deposit(500);
            Console.WriteLine(l1.Balance);
            Console.Write("Old balance " + m1.Balance + ", new balance: ");
            m1.Deposit(10000.90m);
            Console.WriteLine(m1.Balance);
            Console.WriteLine();

            IList<Account> accounts = new List<Account>
            {
                d1, d2, l1, l2, m1, m2
            };

            Bank bank = new Bank(accounts);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The bank:");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(bank);

            // I have changed the formula for calculating the interest, because
            // the given formula returns interest plus amount which is not correct
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Calculated interests:");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Interest = {0:F2} BGN", d1.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} BGN", d2.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} BGN", l1.CalculateInterest(3));
            Console.WriteLine("Interest = {0:F2} BGN", l2.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} BGN", m1.CalculateInterest(6));
            Console.WriteLine("Interest = {0:F2} BGN", m1.CalculateInterest(13));
            Console.WriteLine("Interest = {0:F2} BGN", m2.CalculateInterest(6));
        }
    }
}
