using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task4
{
    internal class Account
    {
        public double balance;
        public string name;
        public string Name { get { return name; } }
        public List<Account> accounts = new List<Account>();
        public Account(double balance = 0.0, string name = "Unnamed Account")
        {
            this.balance = balance;
            this.name = name;
        }
        public bool DoDeposite(double amountToAdd,Account acc)
        {
            if (amountToAdd > 0)
            {
                if (acc != null && amountToAdd > 0)
                    acc.balance += amountToAdd;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DoWithDraw(double amountToDraw,Account acc)
        {
           
            if (acc != null && amountToDraw > 0 && amountToDraw <= acc.balance)
            {
                acc.balance -= amountToDraw;
                return true;
            }
            else
            {
                Console.WriteLine("Withdrawal failed: Invalid amount or insufficient funds");
                return false;
            }
        }
        public void Print(string NamE)
        {
            Account account = Find(NamE);
            if (account != null)
            {
                Console.WriteLine("\n=== YourAccount =================================");
                Console.WriteLine($"balance is: {account.balance}");
                Console.WriteLine($"Name is: {account.name}");
            }
            else
            {
                Console.WriteLine("Account is not found");
            }
        }
        public Account(Account source)
        {
            this.balance = source.balance;
            this.name = source.name;
        }
        public Account Find(string _name)
        {
            Account account = accounts.Find(a => a.Name == _name);
            if (account != null)
            {
                return account;
            }
            else
            {
                return null;
            }
        }
        public override string ToString()
        {
            return $"[Account: {name}, Balance: {balance}]";
        }
        public double GetBalance()
        {
            return balance;
        }
        public void DisplayAll()
        {
            AccountUtil.Display(accounts);
        }
        public void DepositeAll(double Amount)
        {
            AccountUtil.Deposit(accounts,Amount);
        }
        public void DrawAll(double Amount)
        {
            AccountUtil.Withdraw(accounts,Amount);
        }
        public static Account operator +(Account acc1, Account acc2)
        {
            string CombinedName = ($"{acc1.name} {acc2.name}");
            double CombinedBalance = (acc1.balance + acc2.balance);
            return new Account(CombinedBalance,CombinedName);
        }
    }
}