using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task4
{
    internal class SavingsAccount : Account
    {
        private double interestRate;
        public SavingsAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0) : base(balance,name)
        {
            this.interestRate = interestRate;
        }
        public void AddInterest()
        {
            balance += balance * interestRate;
        }
        public override string ToString()
        {
            return ($"Savings Account:[ name is:  {name}, balance is: {balance}]");
        }
    }
}
