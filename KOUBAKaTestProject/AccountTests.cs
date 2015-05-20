using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Models.AccountTypes;
using Models;

namespace KOUBAKaTestProject
{
    /// <summary>
    /// Summary description for AccountTests
    /// </summary>
    [TestFixture]
    public class AccountTests
    {
        private Customer _youngChildCustomer;
        private Customer _oldChildCustomer;

        private ChildSaving _youngChildFirstAccount;
        private ChildSaving _oldChildFirstAccount;

        public void Setup()
        {
            #region SetUp
            _youngChildCustomer = new Customer()
            {
                DateOfBirth = DateTime.Now.AddYears(-15)
            };
            _oldChildCustomer = new Customer()
            {
                DateOfBirth = DateTime.Now.AddYears(-19)
            };

            _youngChildFirstAccount = new ChildSaving()
            {
                AccountNo = "12345",
                Balance = 10000,
                InterestRate = 0.25,
                Owner = _youngChildCustomer
            };
            _oldChildFirstAccount = new ChildSaving()
            {
                AccountNo = "54321",
                Balance = 8754,
                InterestRate = 0.25,
                Owner = _oldChildCustomer
            };
            #endregion
        }

        [Test]
        public void YoungChildInvalidDeposit()
        {
            Setup();
            double toDeposit = 5001;
            double beforeDeposit = _youngChildFirstAccount.Balance;
            _youngChildFirstAccount.Deposit(toDeposit, "Happy birthday!");
            Assert.AreEqual(beforeDeposit, _youngChildFirstAccount.Balance);
        }

        [Test]
        public void YoungChildValidDeposit()
        {
            Setup();
            double toDeposit = 5000;
            double beforeDeposit = _youngChildFirstAccount.Balance;
            double expected = _youngChildFirstAccount.Balance + toDeposit;
            _youngChildFirstAccount.Deposit(toDeposit, "Happy birthday!");
            Assert.AreNotEqual(beforeDeposit, _youngChildFirstAccount.Balance);
            Assert.AreEqual(expected, _youngChildFirstAccount.Balance);
        }

        [Test]
        public void ChildInvalidWithdraw()
        {
            Setup();
            double toWithdraw = 1200;
            double expected = _youngChildFirstAccount.Balance;
            _youngChildFirstAccount.Withdraw(toWithdraw, "To a good friend!");
            Assert.AreEqual(expected, _youngChildFirstAccount.Balance);
        }

        [Test]
        public void ChildValidWithdraw()
        {
            double toWithdraw = 1231;
            double beforeWithdraw = _oldChildFirstAccount.Balance;
            double expected = _youngChildFirstAccount.Balance - toWithdraw;
            _oldChildFirstAccount.Withdraw(toWithdraw, "To a good friend!");
            Assert.AreNotEqual(beforeWithdraw, _oldChildFirstAccount.Balance);
            Assert.AreEqual(expected, _oldChildFirstAccount.Balance);
        }
    }
}
