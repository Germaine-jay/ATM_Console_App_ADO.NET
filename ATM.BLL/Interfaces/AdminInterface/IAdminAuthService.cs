using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.DATA.Models;

namespace ATM.BLL.Interfaces.AdminInterface
{
    internal class IAdminAuthService
    {
    }
    public interface IAuthService : IDisposable
    {
        AdminModelView Login(string userName, string pin);

        bool ResetPin(string? userName, string? oldpin, AdminModelView user);

        void LogOut();
    }
}
