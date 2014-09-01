using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abc_bank
{
    interface ICustomer
    {
        int CustomerAccounts { get; }
        string Name { get; } 
        void OpenAccount(AccountType a);
        void Deposit(AccountType ac, decimal amount, DateTime transactiondate);
        void Withdrawal(AccountType ac, decimal amount, DateTime transactiondate);
        void Statement();
        List<Account> Accounts { get; }
         
    }

    public class Customer: ICustomer
    {
        private string _name { get; set; }
        private List<Account> _accounts { get; set; }

        public Customer(string customername)
        {
            _accounts = new List<Account>();
            _name = customername;
        }
    
        public void  OpenAccount(AccountType at)
        {
            _accounts.Add(new Account(at));
        }

        public void Statement()
        {
            Console.WriteLine(String.Format("#################### Statement  ###############"));
            Console.WriteLine(String.Format("Statment for :{0}", _name));
            foreach (Account a in _accounts)
            {
                Console.WriteLine(String.Format("Account Type :{0}", a.AccountType));
                List<Transaction> transactions = a.Transactions.OrderBy(a1=> a1.TransactionDate).ToList();
                foreach (Transaction t in transactions)
                {
                    Console.WriteLine(String.Format("Transaction Date: {0},Amount: {1}", t.TransactionDate.ToShortDateString(),
                                        t.Amount));
                }
                Console.WriteLine(String.Format("Total: {0},Interest: {1},GrandTotal: {2}", a.TransactionSum, a.Interest, a.TransactionSum+a.Interest));
            }
        }

        public void Deposit(AccountType ac, decimal amount, DateTime transactiondate)
        {
            _accounts.Where(i => i.AccountType == ac).FirstOrDefault().Deposit(amount,transactiondate);
        }

        public void Withdrawal(AccountType ac, decimal amount, DateTime transactiondate)
        {
            _accounts.Where(i => i.AccountType == ac).FirstOrDefault().Withdraw(amount,transactiondate);            
        }
        
        public int CustomerAccounts
        {
            get { return _accounts.Count; }
        }

        public string Name
        {
            get { return _name; }
        }


        public List<Account> Accounts
        {
            get { return _accounts; }
        }
    }
}
