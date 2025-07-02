/*1.
•	You have a class which has methods for transaction for a banking system. (created earlier)
•	Define your own methods for deposit money, withdraw money and balance in the account.
•	Write your own new application Exception class called InsuffientBalanceException. 
•	This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
•	Identify and categorize all possible checked and unchecked exception.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    class Accounts
    {
        int AccountNo;
        string CustomerName, AccountType;
        double amount, balance;
        char TransactionType;

        public Accounts(int AccountNo, string CustomerName, string AccountType, double initialBalance, char TransactionType)
        {
            this.AccountNo = AccountNo;
            this.CustomerName = CustomerName;
            this.AccountType = AccountType;
            balance = initialBalance;
            this.TransactionType = TransactionType;
        }

        public void deposit()
        {
            Console.WriteLine("Enter the amount you want to deposit: ");
            amount = Convert.ToDouble(Console.ReadLine());
            if (amount < 0) throw new ArgumentException("Cant deposit a negative amount");
            balance = balance + amount;
            Console.WriteLine($"{amount} deposited successfully!");
        }

        public void withdraw()
        {
            Console.WriteLine("Enter the amount you want to withdraw: ");
            amount = Convert.ToDouble(Console.ReadLine());
            if (amount < 0) throw new ArgumentException("Cant withdraw a negative amount");
            if (amount > balance) throw new InsufficientBalanceException("Insufficient funds");
            balance = balance - amount;
            Console.WriteLine($"{amount} withdrawn successfully!");
        }

        public void ShowData()
        {
            Console.WriteLine("Account number is : " + AccountNo + " Customer Name is : " + CustomerName + " Account Type is : " + AccountType + " Transaction Type is : " + TransactionType + " Remaining balance is : " + balance);
        }

    }

    class Question1
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter the account number :");
                int AccountNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the customer name :");
                string CustomerName = Console.ReadLine();

                Console.WriteLine("Enter the account type :");
                string AccountType = Console.ReadLine();

                Console.Write("Enter account balance: ");
                double initialBalance = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Transaction Type - W for Withdrawal and D for deposit");
                char TransactionType = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                Accounts acc = new Accounts(AccountNo, CustomerName, AccountType, initialBalance, TransactionType); //object creation
                if (TransactionType == 'D')
                {
                    acc.deposit();
                }
                else if(TransactionType == 'W')
                {
                    acc.withdraw();
                }
                else
                {
                    Console.WriteLine("Invalid transaction");
                }
                acc.ShowData();
                Console.Read();
            }

            catch(InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.Read();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.Read();
            }   
        }
    }

}
