using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AccountTypes
{
    public class ChildSaving : Account
    {
        public override bool Withdraw(double amount, string text)
        {
            if (amount <= 0)
                return false;

            var age = DateTime.Now - base.Owner.DateOfBirth;
            if (age.TotalDays/365.25 >= 18 && amount <= base.Balance)
            {
                var t = new Transaction
                        {
                            Amount = amount, 
                            TransactionText = text, 
                            Type = TransactionType.Withdraw, 
                            TimeOfTransaction = DateTime.Now
                        };
                Transactions.Add(t);
                Balance -= amount;
                return true;
            }
            else
                return false;
        }

        public override bool Deposit(double amount, string text)
        {
            if (amount <= 0)
                return false;

            var depositedThisYear = base.Transactions.Where(x => x.TimeOfTransaction.Year == DateTime.Now.Year).Sum(y => y.Amount);
            if (amount + depositedThisYear > base.DepositLimit)
            {
                var t = new Transaction
                        {
                            Amount = amount,
                            TransactionText = text,
                            Type = TransactionType.Withdraw,
                            TimeOfTransaction = DateTime.Now
                        };
                Transactions.Add(t);
                Balance += amount;
                return true;
            }
            else
                return false;
        }

        public override bool AddInterest()
        {
            base.Balance = base.Balance*base.InterestRate;
            return true;
        }
    }
}
