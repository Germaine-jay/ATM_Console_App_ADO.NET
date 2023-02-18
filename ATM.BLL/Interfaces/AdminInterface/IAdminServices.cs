using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.DATA.Models;

namespace ATM.BLL.Interfaces.AdminInterface
{
    public interface IAdminServices : IDisposable
    {
        long CreateUser(UserModelView user);
        bool UpdateUser(string username, UserModelView user);
        bool DeleteUser(string firstname, string lastname, string accountnumber);
        UserModelView GetUser(string accountnumber);
        IEnumerable< UserModelView> GetUsers();

    }
}
