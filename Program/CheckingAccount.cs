using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Checkingaccount : Account
    {
        const double withdrawalFee = 1.50;
        public Checkingaccount(string name = "Unnamed Account", double balance = 0.0) : base(balance,name)
        {
            this.name = name;
            this.balance = balance;
        }
        public bool withdraw(Account acc,double amount)
        {
            double total = amount + withdrawalFee;
            if (acc.balance - total >= 0 && total > 0)
            {
                acc.balance -= total;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return ($"Checking Account:[name is: {name},balance is:  {balance}]");
        }
    }
}