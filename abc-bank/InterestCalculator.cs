using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abc_bank
{
    public class InterestCalculator
    {
        private List<IInterestRule> _interestRules;

        public InterestCalculator()
        {
            _interestRules = new List<IInterestRule>();
            _interestRules.Add(new CheckingAccountRule());
            _interestRules.Add(new SavingsAccountRule());
            _interestRules.Add(new MaxiSavingsAccountRule());
        }

        public decimal CalculateInterest(Account a)
        {
            return _interestRules.First(i => i.IsMatch(a)).CalculateInterest(a);
        }
    }
}
