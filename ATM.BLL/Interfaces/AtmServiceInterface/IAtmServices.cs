using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.BLL.Interfaces.AtmServiceInterface
{
    public interface IAtmServices
    {
        void Transfer(long amount, DateTime date, string discription);
        void Withdrawal(long amount, DateTime date, string discription);
        void Deposit(long amount, DateTime date, string discription);
        void Recharge(long amount, DateTime date, string discription);
    }
}
