using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abc_bank
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        private Transaction()
        {

        }

        public Transaction(decimal amount, DateTime transactiondate)
        {
            Amount = amount;
            TransactionDate = transactiondate;
        }
    }

    
}
