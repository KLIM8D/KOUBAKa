using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Account
    {
        public string AccountNo { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Customer Owner { get; set; }
        public double DepositLimit { get; set; }

        public abstract bool Withdraw(double amount, string text);

        public abstract bool Deposit(double amount, string text);

        public abstract bool AddInterest();
    }
}
