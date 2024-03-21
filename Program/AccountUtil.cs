using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class AccountUtil : Account
    {
        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }
        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.DoDeposite(amount,acc))
                    Console.WriteLine($"Deposited {amount} ToBecome {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} ToBecome {acc}");
            }
        }
        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.DoWithDraw(amount,acc))
                    Console.WriteLine($"Withdrew {amount} ToBecome {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} ToBecome {acc}");
            }
        }
    }
}
