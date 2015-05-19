using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace Models
{
    public enum TransactionType
    {
        Deposit, Withdraw
    }

    public class Transaction
    {
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public string TransactionText { get; set; }
        public DateTime TimeOfTransaction { get; set; }
    }
}
