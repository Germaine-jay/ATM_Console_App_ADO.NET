using ATM.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ATM.DATA.Models;
using Transaction = ATM.DATA.Models.Transaction;
using ATM.BLL.Implementation.UserServices;
using ATM.BLL.Interfaces.AtmServiceInterface;

namespace ATM.BLL.Implementation.AtmServices
{
    public class TransactionOptions : IAtmServices
    {
        public static string? AccountNumber = AtmServices.AccountNumber;
        public static long AccountBalance = AtmServices.AccountBalance;
        public static long Balance;

        protected static List<Transaction> AllTransactions = new List<Transaction>();
        public void Deposit(long amount, DateTime date, string discription)
        {
            var limit = 1000000;
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "AMOUNT OF DEPOSIT MUST BE POSITIVE");
            if (amount >= limit) throw new ArgumentOutOfRangeException(nameof(amount), "AMOUNT SHOULD NOT BE OVER A MILLION");

            Balance = AccountBalance + amount;
            GetBalance.SetBalance(AccountNumber, Balance);

            var deposit = new Transaction(amount, date, "deposit", discription);
            AllTransactions.Add(deposit);
        }

        public void Withdrawal(long amount, DateTime date, string discription)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "AMOUNT OF WITHDRAWAL MUST BE +VE");
            }
            if (AccountBalance - amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Not sufficient funds for this withdrawal");
            }

            Balance = AccountBalance - amount;
            GetBalance.SetBalance(AccountNumber, Balance);

            var withdrawal = new Transaction(-amount, date, "withdrawal", discription);
            AllTransactions.Add(withdrawal);
        }

        public void Recharge(long amount, DateTime date, string discription)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "AMOUNT OF WITHDRAWAL MUST BE +VE");
            }
            if (AccountBalance - amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Not sufficient funds for this withdrawal");
            }

            Balance = AccountBalance - amount;
            GetBalance.SetBalance(AccountNumber, Balance);

            var Recharge = new Transaction(-amount, date, "Recharge", discription);
            AllTransactions.Add(Recharge);
        }

        public void Transfer(long amount, DateTime date, string discription)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "AMOUNT TO WITHDRAW MUST BE +VE");
            }
            if (AccountBalance - amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Insufficient funds for this withdrawal");
            }

            Balance = AccountBalance - amount;
            GetBalance.SetBalance(AccountNumber, Balance);

            var transfer = new Transaction(-amount, date, "Transfer", discription);
            AllTransactions.Add(transfer);
        }
    }
}
