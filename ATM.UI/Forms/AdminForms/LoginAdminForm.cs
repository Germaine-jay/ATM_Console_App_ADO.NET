using ATM.BLL.Views;
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

            AdminView.LoginAdmin(AdminName, Adminpin);              
        }
    }
}
