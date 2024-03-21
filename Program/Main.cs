using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Xml.Linq;

namespace Task4
{
    internal class Bank
    {

        public static int readUserOption() //UI
        {
            int menuOption;
            do
            {
                Console.WriteLine("   welcome to Bank      ");
                Console.WriteLine("0 - do you want to draw from yourBalance");    //withDraw
                Console.WriteLine("1 - do you want to deposite into yourBalance?");  //Deposite
                Console.WriteLine("2 - do you want to show your AccountDetails? ");  //Print
                Console.WriteLine("3 - do you want to add Account into this Bank?");  //Add
                Console.WriteLine("4 - do you want to deposite Money into All Accounts?");  //Deposite All
                Console.WriteLine("5 - do you want to draw Money from All Accounts?");      //Draw All
                Console.WriteLine("6 - Display All Accounts");
                Console.WriteLine("7 - do you want to Open SavingAccount Functions?: ");    //SavingsAccounts
                Console.WriteLine("8 - do you want to Open CheckingAccount Functions?: ");  //ChekingAccount
                Console.WriteLine("9 - do you want to Open TrustAccount Functions?: ");     //TrustAccount
                Console.WriteLine("10 - do you want to Add & Combine Two Accounts?: ");
                Console.WriteLine("11 - Quit");                                       //Quit
                Console.Write("Enter your Option: ");
                menuOption = Convert.ToInt32(Console.ReadLine());
            } while (menuOption < 0 || menuOption > 11);
            return menuOption;
        }
        public static int Functions(string Page)
        {
            int PageOption;
            do
            {
                Console.WriteLine($"   Functions of {Page}         ");
                Console.WriteLine("1 - Add Account");
                Console.WriteLine("2 - Withdraw from Account");
                Console.WriteLine("3 - Deposit into Account");
                Console.WriteLine("4 - Display Account Details");
                Console.WriteLine("5 - Goback");
                Console.Write("Enter your Option: ");
                PageOption = Convert.ToInt32(Console.ReadLine());
            } while (false);
            return PageOption;
        }
        static void Main(string[] args)
        {
            Account account = new Account();
            Account savAcc = new SavingsAccount();
            Account ChecACC = new Checkingaccount();
            Account TrustACC = new TrustAccount();
            List<Account> savAccounts = new List<Account>();
            List<Account> ChecAccount = new List<Account>();
            List<Account> trustAccount = new List<Account>();
            int option;
            do
            {
                option = readUserOption();
                switch (option)
                {
                    case 0:
                        {
                            Console.Write("how much money that you draw it?: ");
                            double drawBalance = double.Parse(Console.ReadLine());
                            Console.Write("what is your name?: ");
                            string name = Console.ReadLine();
                            {
                                bool result = account.DoWithDraw(drawBalance, account.Find(name));
                                if (result)
                                {
                                    Console.WriteLine("Withdrawal successful");
                                    Console.WriteLine("                     ");
                                }
                                else
                                {
                                    Console.WriteLine("Withdrawal failed");
                                    Console.WriteLine("Account not found.");
                                    Console.WriteLine("                  ");
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            Console.Write("how much money that you deposit into Account?: ");
                            double depositBalance = double.Parse(Console.ReadLine());
                            Console.Write("what is your name?: ");
                            string name = Console.ReadLine();
                            {
                                bool result = account.DoDeposite(depositBalance, account.Find(name));
                                if (result)
                                {
                                    Console.WriteLine("Deposit successful");
                                    Console.WriteLine("                     ");
                                }
                                else
                                {
                                    Console.WriteLine("Deposit failed");
                                    Console.WriteLine("Account not found.");
                                    Console.WriteLine("                  ");
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("what is your name?: ");
                            string namee = Console.ReadLine();
                            account.Print(namee);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("what is your name?: ");
                            string Name = Console.ReadLine();
                            Console.Write("what is your balance?: ");
                            int Balance = int.Parse(Console.ReadLine());
                            account.accounts.Add(new Account(Balance, Name));
                            Console.WriteLine("Process is Succeed");
                            Console.WriteLine("                  ");
                            break;
                        }
                    case 4:
                        {
                            Console.Write("how much money that you deposite into All Accounts?: ");
                            double depositeForAll = double.Parse(Console.ReadLine());
                            account.DepositeAll(depositeForAll);
                            break;
                        }
                    case 5:
                        {
                            Console.Write("how much money that you draw from All Accounts?: ");
                            double depositeForAll = double.Parse(Console.ReadLine());
                            account.DrawAll(depositeForAll);
                            break;
                        }
                    case 6:
                        {
                            account.DisplayAll();
                            break;
                        }
                    case 7:
                        {

                            var saveACC = new List<Account>();
                            int Option;
                            do
                            {
                                Option = Functions("SavingAccount");
                                switch (Option)
                                {
                                    case 1:
                                        {
                                            Console.Write("what is your name?: ");
                                            string name = Console.ReadLine();
                                            Console.Write("what is your balance?: ");
                                            int balance = int.Parse(Console.ReadLine());
                                            Account account1 = new SavingsAccount(name, balance);
                                            savAccounts.Add(account1);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Write("how much money that you draw it?: ");
                                            double drawBalance = double.Parse(Console.ReadLine());
                                            AccountUtil.Withdraw(savAccounts, drawBalance);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Write("how much money that you Deposit it?: ");
                                            double depositBalance = double.Parse(Console.ReadLine());
                                            AccountUtil.Deposit(savAccounts, depositBalance);
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Displaying all Savings Accounts:");
                                            AccountUtil.Display(savAccounts);
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("Quitting From SavingAccountPage");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Invalid Option");
                                            break;
                                        }
                                }
                            } while (Option != 5);
                            break;
                        }
                    case 8:
                        {
                            var ChecAccounts = new List<Account>();
                            int Option;
                            do
                            {
                                Option = Functions("CheckAccount");
                                switch (Option)
                                {
                                    case 1:
                                        {
                                            Console.Write("what is your name?: ");
                                            string Name = Console.ReadLine();
                                            Console.Write("what is your balance?: ");
                                            int Balance = int.Parse(Console.ReadLine());
                                            ChecAccount.Add(new Checkingaccount(Name, Balance));
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Write("how much money that you draw it?: ");
                                            double DrawBalance = double.Parse(Console.ReadLine());
                                            AccountUtil.Withdraw(ChecAccount, DrawBalance);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Write("how much money that you Deposit it?: ");
                                            double DepositBalance = double.Parse(Console.ReadLine());
                                            AccountUtil.Deposit(ChecAccount, DepositBalance);
                                            break;
                                        }
                                    case 4:
                                        {
                                            AccountUtil.Display(ChecAccount);
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("Quitting From CheckAccountPage");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Invalid Option");
                                            break;
                                        }
                                }
                            } while (Option != 5);
                            break;
                        }
                    case 9:
                        {
                            var trustAccounts = new List<Account>();
                            int Option;
                            do
                            {
                                Option = Functions("TrustAccount");
                                switch (Option)
                                {
                                    case 1:
                                        {
                                            Console.Write("what is your name?: ");
                                            string Name = Console.ReadLine();
                                            Console.Write("what is your balance?: ");
                                            int Balance = int.Parse(Console.ReadLine());
                                            trustAccount.Add(new TrustAccount(Name, Balance));
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Write("how much money that you draw it?: ");
                                            double DrawBalance = double.Parse(Console.ReadLine());
                                            AccountUtil.Withdraw(trustAccount, DrawBalance);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Write("how much money that you Deposit it?: ");
                                            double DepositBalance = double.Parse(Console.ReadLine());
                                            AccountUtil.Deposit(trustAccount, DepositBalance);
                                            break;
                                        }
                                    case 4:
                                        {
                                            AccountUtil.Display(trustAccount);
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.WriteLine("Quitting From CheckAccountPage");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Invalid Option");
                                            break;

                                        }
                                }
                            } while (Option != 5);
                            break;
                        }
                    case 10:
                        {

                                Console.WriteLine($"<======Enter AccountDate1=======>");
                                Console.Write($"what is nameAccount1?: ");
                                string NameACC = Console.ReadLine();
                                Console.Write($"What is BalanceAccount1?: ");
                                double balanceAccount = double.Parse(Console.ReadLine());
                                Account acc1 = new Account(balanceAccount,NameACC);

                                Console.WriteLine($"<======Enter AccountDate2=======>");
                                Console.Write($"what is nameAccount2?: ");
                                string NameACC2 = Console.ReadLine();
                                Console.Write($"What is BalanceAccount1?: ");
                                double balanceAccount2 = double.Parse(Console.ReadLine());
                                Account acc2 = new Account(balanceAccount2, NameACC2);

                                Account combinedAccount = acc1+acc2;
                                Console.WriteLine($"Combined Account: {combinedAccount}");
                                break;
                        }
                    case 11:
                        {
                            Console.WriteLine("Quitting the program.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid option, Please choose a valid option.");
                            Console.WriteLine("                                             ");
                            break;
                        }
                }
            } while (option != 11);
        }
    }
}
