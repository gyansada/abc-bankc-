using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abc_bank
{
    public interface IInterestRule
    {
         bool IsMatch(Account a);
         decimal CalculateInterest(Account a);
    }

    public class CheckingAccountRule : IInterestRule
    {

        public bool IsMatch(Account a)
        {
            return a.AccountType == AccountType.CHECKING;
        }

        public decimal CalculateInterest(Account a)
        {
            decimal amount = 0.0M;
            if (a.TransactionSum == 0) return amount;
            amount += a.TransactionSum * 0.001M;
            return amount;
        }
    }

    public class SavingsAccountRule : IInterestRule
    {
        public bool IsMatch(Account a)
        {
            return a.AccountType == AccountType.Saving;
        }

        public decimal CalculateInterest(Account a)
        {
            decimal amount = 0.0M;
            if (a.TransactionSum == 0) return amount;
            if (a.TransactionSum <= 1000)
            {
                amount += a.TransactionSum * 0.001M;
            }
            if (a.TransactionSum > 1000)
            {
                amount += 1000 * 0.001M;
                amount += (a.TransactionSum - 1000M) * 0.002M;
            }
            return amount;
        }
    }

    //MaxiSavingsAccountRule
    public class MaxiSavingsAccountRule : IInterestRule
    {
        public bool IsMatch(Account a)
        {
            return a.AccountType == AccountType.MAXI_SAVINGS;
        }

        public decimal CalculateInterest(Account a)
        {
            decimal amount = 0.0M;
            if (a.TransactionSum == 0) return amount;

            if (a.TransactionSum <= 1000)
            {
                amount = a.TransactionSum * 0.02M;
            }
            if ((a.TransactionSum > 1000) && (a.TransactionSum <= 2000))
            {
                amount = 1000 * 0.02M;
                amount += (a.TransactionSum - 1000) * 0.05M;
            }
            if ((a.TransactionSum > 2000))
            {
                amount = 1000 * 0.02M;
                amount += 1000 * 0.05M;
                amount += (a.TransactionSum - 2000) * 0.01M;
            }
            return amount;
        }
    }

}
