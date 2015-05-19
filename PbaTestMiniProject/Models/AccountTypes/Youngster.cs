using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AccountTypes
{
    class Youngster : Account
    {
        public override bool Withdraw(double amount, string text)
        {
            if (amount <= 0)
                return false;

            if (amount <= base.Balance)
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

            if (amount <= base.Balance)
            {
                var t = new Transaction
                {
                    Amount = amount,
                    TransactionText = text,
                    Type = TransactionType.Deposit,
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
            throw new NotImplementedException();
        }
    }
}
