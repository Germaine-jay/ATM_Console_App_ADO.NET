using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.DATA.Models
{
    /*internal class TransactionViewModel
    {
    }*/
    public class Transaction
    {
        public long Amount { get; }
        public DateTime Date { get; }
        public string Type { get; }
        public string Description { get; }

        public Transaction(long amount, DateTime date, string type, string description)
        {
            Amount = amount;
            Date = date;
            Type = type;
            Description = description;
        }
    }
}
