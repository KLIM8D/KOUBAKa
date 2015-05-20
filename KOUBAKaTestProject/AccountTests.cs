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
        public AccountTests()
        {
            _youngChildCustomer = new Customer()
            {
                DateOfBirth = DateTime.Now.AddYears(-15)
            };
            _oldChildCustomer = new Customer() {
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

            };
        }
        [TestCase]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
