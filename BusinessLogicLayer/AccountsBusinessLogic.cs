using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AccountsBusinessLogic
    {
        public static void AddAccount(string accountNo, double balance, double interestRate, string ownerSsn, double depositLimit)
        {
            var customer = CustomerBusinessLogic.GetCustomer(ownerSsn);
            string type= string.Empty;
            int age = 
                (DateTime.Now.Year - customer.DateOfBirth.Year - 1) + (((DateTime.Now.Month > customer.DateOfBirth.Month) 
                || ((DateTime.Now.Month == customer.DateOfBirth.Month) && (DateTime.Now.Day >= customer.DateOfBirth.Day))) ? 1 : 0);

            if (balance > 50000)
            {
                /* Elite */
                type = "EliteSaving";
            }
            else if (age <= 18)
            {
                /* Child saving */
                type = "ChildSaving";
            }
            else if (age >= 20)
            {
                /* Youngster */
                type = "Youngster";
            }
            else if (age >= 65)
            {
                /* senior */
                type = "Senior";
            }
            AccountsDal.AddAccount(accountNo, balance, interestRate, ownerSsn, depositLimit, type);
        }
    }
}
