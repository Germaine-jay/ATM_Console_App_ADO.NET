using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.BLL.Interfaces.AtmServiceInterface
{
    public interface IAtmOperations
    {
        string TrasationOperation(long amount, string discription, string type, DateTime date);
        string TransferTrasationOperation(long amount, string account, string discription, string type, DateTime date);
    }
}
