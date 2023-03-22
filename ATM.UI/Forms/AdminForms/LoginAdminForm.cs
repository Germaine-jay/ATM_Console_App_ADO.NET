using ATM.BLL.Views;
using ATM_App;
using System;

namespace ATM.UI.Forms.AdminForms
{
    public class LoginAdminForm
    {
       public static void loginadminForm()
        {
            Console.WriteLine("\t===> LOGIN ADMIN\n");

            Console.WriteLine(" Enter Name");
            string AdminName = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter pin");
            string Adminpin = Console.ReadLine().ToLower();

            var login = AdminView.LoginAdmin(AdminName, Adminpin);
            if(login== false)
            {
                StartApp.AccessOptions();
            }
            
        }
    }
}
