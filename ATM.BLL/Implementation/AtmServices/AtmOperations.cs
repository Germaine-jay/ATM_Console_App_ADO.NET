using ATM.BLL.Implementation.UserServices;
using ATM.BLL.Interfaces.AtmServiceInterface;
using Transaction = ATM.DATA.Models.Transaction;


namespace ATM.BLL.Implementation.AtmServices
{
    public class AtmOperations : IAtmOperations
    {
        public static string? AccountNumber = AtmServices.AccountNumber;
        public static long AccountBalance = AtmServices.AccountBalance;
        public static long Balance;

        protected static List<Transaction> AllTransactions = new List<Transaction>();

        public void TrasationOperation(long amount, string discription, string type, DateTime date)
        {

            var balance = AccountBalance - amount;

            Balance = balance;
            var output = GetBalance.SetBalance(AccountNumber, balance);
            if (output == "Successfully Updated")
            {
                var Transac = new Transaction(-amount, date, type, discription);
                AllTransactions.Add(Transac);

                Console.WriteLine($"{discription} of #{amount} Successful");
            }
            Console.WriteLine($"{discription} of #{amount} Unsuccessful");


        }

        public void DepositTrasationOperation(long amount, string discription, string type, DateTime date)
        {

            var balance = AccountBalance + amount;

            Balance = balance;
            var output = GetBalance.SetBalance(AccountNumber, balance);
            if (output == "Successfully Updated")
            {
                var Transac = new Transaction(amount, date, type, discription);
                AllTransactions.Add(Transac);

                Console.WriteLine($"{discription} of #{amount} Successful");
            }
            Console.WriteLine($"{discription} of #{amount} Unsuccessful");

        }

        public void TransferTrasationOperation(long amount, string account, string discription, string type, DateTime date)
        {

            var balance = AccountBalance - amount;
            Balance = balance;

            GetBalance.SetBalance(AccountNumber, balance);
            var output = GetBalance.SetRecieverBalance(account, amount);
            if (output == "Successfully Updated")
            {
                var Transac = new Transaction(-amount, account, date, type, discription);
                AllTransactions.Add(Transac);
                Console.WriteLine($"{discription} of #{amount} Successful");
            }
            Console.WriteLine($"{discription} of #{amount} Unsuccessful");


        }
    }
}
