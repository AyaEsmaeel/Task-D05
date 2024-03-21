using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task4
{
    internal class TrustAccount : Account
    {
        private const double bonusThreshold = 5000.00;
        private const double bonus = 50.00;
        private const int maxYear = 3;
        private const double maxPercentage = 0.20;
        private int withdrawalsThisYear;

        public TrustAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0): base(balance,name)
        {
            withdrawalsThisYear = 0;
        }
        public bool Deposit(double amount,Account acc)
        {
            if (base.DoDeposite(amount,acc))
            {
                if (amount >= bonusThreshold)
                    balance += bonus;
                return true;
            }
            return false;
        }
        public bool Withdraw(double amount,Account acc)
        {
            if (withdrawalsThisYear < maxYear && amount <= balance * maxPercentage)
            {
                withdrawalsThisYear++;
                return base.DoWithDraw(amount, acc);
            }
            return false;
        }
        public override string ToString()
        {
            return $"Trust Account:[name is: {name}, Balance is: {balance}";
        }
    }
}
