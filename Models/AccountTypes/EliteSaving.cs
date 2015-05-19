using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AccountTypes
{
    class EliteSaving : Account
    {
        public override bool Withdraw(double amount, string text)
        {
            throw new NotImplementedException();
        }

        public override bool Deposit(double amount, string text)
        {
            throw new NotImplementedException();
        }

        public override bool AddInterest()
        {
            throw new NotImplementedException();
        }
    }
}
