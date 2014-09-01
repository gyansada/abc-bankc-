using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abc_bank
{
    public class Bank
    {
        private List<Customer> _customers;
 
        public Bank()
        {
            _customers = new List<Customer>();
        }

        public void AddCustomer(Customer c)
        {
            _customers.Add(c);
        }

        public void StatementListAccount()
        {
            Console.WriteLine("################# StatementListAccounts ###################");
            if (_customers.Count > 0)
            {
                Console.WriteLine("Total Customers:", _customers.Count);
                foreach (Customer c in _customers)
                {
                    Console.WriteLine(String.Format("Customer:{0} has {1} working accounts",c.Name, c.CustomerAccounts));
                }
            }
        }

        public void TotalInterestPaid()
        {
            decimal amount = 0.0M;
            foreach (Customer c in _customers)
            {
                foreach (Account a in c.Accounts)
                {
                    amount += a.Interest;
                }
            }
            Console.WriteLine("################# TotalInterestPaid ###################");
            Console.WriteLine(String.Format("Total interest paid for all accounts:{0}", amount));
        }
    }
}
