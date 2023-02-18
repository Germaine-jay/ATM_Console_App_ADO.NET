using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.BLL.Interfaces.UserInterface
{
    public interface IUserServices:IDisposable
    {
        bool UpdateBalance(string accountnumber, long balance);
    }
}
