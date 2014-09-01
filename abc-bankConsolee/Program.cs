using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using abc_bank;
namespace abc_bankConsolee
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string command;
                Bank bank = new Bank();

                //Customer John
                Customer customer = new Customer("John");
                bank.AddCustomer(customer);
                //Checking
                customer.OpenAccount(AccountType.CHECKING);
                customer.Deposit(AccountType.CHECKING, 1000, DateTime.Parse("1/1/2014"));
                customer.Withdrawal(AccountType.CHECKING, 500, DateTime.Parse("1/5/2014"));
                //Savings
                customer.OpenAccount(AccountType.Saving);
                customer.Deposit(AccountType.Saving, 6000, DateTime.Parse("1/1/2014"));
                customer.Withdrawal(AccountType.Saving, 300, DateTime.Parse("1/5/2014"));
                //MAXI_SAVINGS
                customer.OpenAccount(AccountType.MAXI_SAVINGS);
                customer.Deposit(AccountType.MAXI_SAVINGS, 4000, DateTime.Parse("1/1/2014"));
                customer.Withdrawal(AccountType.MAXI_SAVINGS, 500, DateTime.Parse("1/5/2014"));
                customer.Statement();

                bank.StatementListAccount();
                bank.TotalInterestPaid();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            Console.ReadLine();
        }


        

        
    }
}
