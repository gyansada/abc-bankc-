using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abc_bank
{
    public interface IAccount
    {
        void Deposit(decimal amount, DateTime transactiondate);
        void Withdraw(decimal amount, DateTime transactiondate);
    }
    public class Account
    {
        private AccountType _accountType { get; set; }
        private List<Transaction> _transactions;
        private InterestCalculator _interestCalculator;
        private Account()
        {
        }

        public AccountType AccountType 
        {
            get { return _accountType; } 
        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
        }

        public Account(AccountType type)
        {
            _accountType = type;
            _transactions = new List<Transaction>();
            _interestCalculator = new InterestCalculator();
        }

        public void Deposit(decimal amount, DateTime transactiondate)
        {   
            if (amount <= 0) throw new Exception("amount must be greater than zero");
            _transactions.Add(new Transaction(amount,transactiondate));
        }

        public void Withdraw(decimal amount, DateTime transactiondate)
        {
            if (amount <= 0) throw new Exception("amount must be greater than zero");
            _transactions.Add(new Transaction(amount*-1,transactiondate));
        }

        public decimal TransactionSum
        {
            get
            {
                decimal amount = 0.0M;
                foreach (Transaction t in _transactions)
                {
                    amount += t.Amount;
                }

                return amount ;
            }
        }

        public decimal Interest
        {
            get
            {
                return _interestCalculator.CalculateInterest(this);           
            }
        }
    }

    public enum AccountType
    {
        CHECKING=0,Saving=1,MAXI_SAVINGS=2
    }

    
}
