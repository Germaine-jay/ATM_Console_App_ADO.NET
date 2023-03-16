using ATM.BLL.Implementation.UserServices;
using ATM.BLL.Interfaces.AtmServiceInterface;
using ATM.BLL.Interfaces.UserInterface;
using System.Collections.Generic;
using Transaction = ATM.DATA.Models.Transaction;


namespace ATM.BLL.Implementation.AtmServices
{
    public class AtmOperations : IAtmOperations
    {
        public static string? AccountNumber = AtmServices.AccountNumber;
        public static long AccountBalance = AtmServices.AccountBalance;
        public static long Balance;

        protected static List<Transaction> AllTransactions = new List<Transaction>();

        public string TrasationOperation(long amount, string discription, string type, DateTime date)
        {
            var limit = 1000000;
            if (amount <= 1 )
            {
                return "Inalid Amount: Amount must be greater than #1";
            }
            else if (AccountBalance - amount <= 1)
            {
                return "Unable to compplete Transation: Your balance is low";
            }
            else if (amount > limit)
            {
                return "Unable to compplete Transation: amount must not be more than a million";
            }

            else
            {
               var balance = AccountBalance - amount;

                Balance = balance;
                GetBalance.SetBalance(AccountNumber, balance);

                var Transac = new Transaction(-amount, date, type, discription);
                AllTransactions.Add(Transac);

                return $"{discription} of #{amount} Successful";
            }
        }

        public string DepositTrasationOperation(long amount, string discription, string type, DateTime date)
        {
            var limit = 1000000;
            if (amount <= 1)
            {
                return "Inalid Amount: Amount must be greater than #1";
            }
            else if (AccountBalance - amount <= 1)
            {
                return "Unable to compplete Transation: Your balance is low";
            }
            else if (amount > limit)
            {
                return "Unable to compplete Transation: amount must not be more than a million";
            }

            else
            {
                var balance = AccountBalance + amount;
                Balance = balance;
                GetBalance.SetBalance(AccountNumber, balance);

                var Transac = new Transaction(-amount, date, type, discription);
                AllTransactions.Add(Transac);

                return $"{discription} of #{amount} Successful";
            }
        }

        public string TransferTrasationOperation(long amount, string account, string discription, string type, DateTime date)
        {
            var limit = 1000000;
            if (amount <= 1)
            {
                return "Inalid Amount: Amount must be greater than zero";
            }
            if (AccountBalance - amount <= 1)
            {
                return "Unable to compplete Transation: Your balance is low";
            }
            else if (amount > limit)
            {
                return "Unable to compplete Transation: amount must not be more than a million";
            }
            else
            {
                var balance = AccountBalance - amount;
                Balance = balance;

                GetBalance.SetBalance(AccountNumber, balance);
                GetBalance.SetRecieverBalance(account, amount);

                var Transac = new Transaction(-amount, account, date, type, discription);
                AllTransactions.Add(Transac);

                return $"{discription} of #{amount} was Successful";

            }
        }
    }
}
