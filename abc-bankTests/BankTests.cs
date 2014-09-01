using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bankTests
{
    [TestClass]
    public class BankTests
    {
        public Bank bank;

        [TestInitialize]
        public void TestInitialize()
        {
            bank = new Bank();
            
        }

        // Few test to validate the bank methods
        [TestMethod]
        public void TestNoDepositTotalZero()
        {
            Customer c = new Customer("John");
            bank.AddCustomer(c);
            c.OpenAccount(AccountType.CHECKING);

            Assert.AreEqual(c.Accounts.First().TransactionSum, 0);
            Assert.AreEqual(c.Accounts.First().Interest, 0);
        }

        [TestMethod]
        public void TestOneDepositAndTotal()
        {
            Customer c = new Customer("John");
            bank.AddCustomer(c);
            c.OpenAccount(AccountType.CHECKING);
            c.Deposit(AccountType.CHECKING, 1000, DateTime.Parse("1/1/2014"));

            Assert.AreEqual(c.Accounts.First().TransactionSum, 1000);
            Assert.AreEqual(c.Accounts.First().Interest, 1);
        }

        [TestMethod]
        public void TestOneDepositWithdrawalAndTotal()
        {
            Customer c = new Customer("John");
            bank.AddCustomer(c);
            c.OpenAccount(AccountType.CHECKING);
            c.Deposit(AccountType.CHECKING, 1000, DateTime.Parse("1/1/2014"));
            c.Withdrawal(AccountType.CHECKING, 400, DateTime.Parse("1/1/2014"));

            Assert.AreEqual(c.Accounts.First().TransactionSum, 600);
            Assert.AreEqual(c.Accounts.First().Interest, 0.6M);
        }

        [TestMethod]
        public void TestOpenThreeAccounts()
        {
            Customer c = new Customer("John");
            bank.AddCustomer(c);
            c.OpenAccount(AccountType.CHECKING);
            c.OpenAccount(AccountType.MAXI_SAVINGS);
            c.OpenAccount(AccountType.Saving);

            Assert.AreEqual(c.CustomerAccounts, 3);
        }

        [TestMethod]
        public void TestOneDepositToSavingsAccount()
        {
            Customer c = new Customer("John");
            bank.AddCustomer(c);
            c.OpenAccount(AccountType.Saving);
            c.Deposit(AccountType.Saving, 10000, DateTime.Parse("1/1/2014"));
            c.Withdrawal(AccountType.Saving, 4000, DateTime.Parse("1/1/2014"));

            Assert.AreEqual(c.Accounts.First().TransactionSum, 6000);
            Assert.AreEqual(c.Accounts.First().Interest, 11);
        }

        [TestMethod]
        public void TestOneDepositToMaxiSavingsAccount()
        {
            Customer c = new Customer("John");
            bank.AddCustomer(c);
            c.OpenAccount(AccountType.MAXI_SAVINGS);
            c.Deposit(AccountType.MAXI_SAVINGS, 10000, DateTime.Parse("1/1/2014"));
            c.Withdrawal(AccountType.MAXI_SAVINGS, 4000, DateTime.Parse("1/1/2014"));

            Assert.AreEqual(c.Accounts.First().TransactionSum, 6000);
            Assert.AreEqual(c.Accounts.First().Interest, 110);
        }

    }
}
