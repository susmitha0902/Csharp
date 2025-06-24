/*Inheritance:

1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
D->Deposit
W->Withdrawal

-write a function that updates the balance depending upon the transaction type

	-If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance

  function  Credit(int amount) 

	-If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance

  Debit(int amt) function 

-Pass the other information like Account no, customer name, acc type through constructor

-write and call the show data method to display the values. 
 */

using System;

namespace Assignment_3
{
    class Accounts
    {
         int AccountNo;
         string CustomerName, AccountType;
         double amount,balance;
         char TransactionType;

       public Accounts(int AccountNo, string CustomerName, string AccountType, char TransactionType)
        {
            this.AccountNo = AccountNo;
            this.CustomerName = CustomerName;
            this.AccountType = AccountType;
            this.TransactionType = TransactionType;
        }
        
        public void credit(double balance)
        {
            Console.WriteLine("Enter the amount you want to deposit: ");
            amount = Convert.ToDouble(Console.ReadLine());
            this.balance = balance + amount;
        }

        public void debit(double balance)
        {
            Console.WriteLine("Enter the amount you want to withdraw: ");
            amount = Convert.ToDouble(Console.ReadLine());
            this.balance = balance - amount;
        }

        public void ShowData()
        {
            Console.WriteLine("Account number is : " + AccountNo + " Customer Name is : " + CustomerName + " Account Type is : " + AccountType+" Transaction Type is : "+TransactionType+" Remaining balance is : "+balance);
        }

    }

    class Question1
    {
        public static void Main()
        {
            Console.WriteLine("Enter the account number :");
            int AccountNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the customer name :");
            string CustomerName = Console.ReadLine();
            Console.WriteLine("Enter the account type :");
            string AccountType = Console.ReadLine();
            Console.WriteLine("Enter Transaction Type - W for Withdrawal and D for deposit");
            char TransactionType = char.ToUpper(Convert.ToChar(Console.ReadLine()));
            Accounts acc = new Accounts(AccountNo, CustomerName, AccountType, TransactionType); //object creation
            Console.WriteLine("Enter your account balance");
            double balance = Convert.ToDouble(Console.ReadLine());
            if(TransactionType == 'D')
            {
                acc.credit( balance);
            }
            else
            {
                acc.debit(balance);
            }
            acc.ShowData();
            Console.Read();   
        }
    }

}
