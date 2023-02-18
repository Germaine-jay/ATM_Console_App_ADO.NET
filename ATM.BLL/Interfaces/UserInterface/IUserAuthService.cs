using ATM.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.BLL.Interfaces.UserInterface
{
    public interface IUserAuthService : IDisposable
    {
        UserModelView LoginCustomer(string accountnumber, string pin);
        bool ResetPin(string? userName, string? oldpin, UserModelView user);
    }
}
