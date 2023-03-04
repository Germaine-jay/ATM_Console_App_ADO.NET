using ATM.BLL.Interfaces;

using Transaction = ATM.DATA.Models.Transaction;
using ATM.BLL.Implementation.UserServices;
using ATM.BLL.Interfaces.AtmServiceInterface;

namespace ATM.BLL.Implementation.AtmServices
{
    public class TransactionOptions : IAtmServices
    {

        AtmOperations atmOperations = new AtmOperations();
        public void Deposit(long amount, DateTime date, string discription)
        {
            atmOperations.DepositTrasationOperation(amount, discription, "Deposit", DateTime.Now);
        }

        public void Withdrawal(long amount, DateTime date, string discription)
        {
            atmOperations.TrasationOperation(amount, discription, "Withdrawal", DateTime.Now);
        }

        public void Recharge(long amount, DateTime date, string discription)
        {
            atmOperations.TrasationOperation(amount, discription, "Recharge", DateTime.Now);
        }

        public void Transfer(long amount, string account, DateTime date, string discription)
        {
            atmOperations.TransferTrasationOperation(amount, account, discription, "Transfer", DateTime.Now);
        }
    }
}
