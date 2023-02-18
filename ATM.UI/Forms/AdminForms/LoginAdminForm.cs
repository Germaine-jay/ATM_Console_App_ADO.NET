using ATM.BLL.Views;
using System;

namespace ATM.UI.Forms.AdminForms
{
    public class LoginAdminForm
    {
       public void loginForm()
        {
            Console.WriteLine("\t===> LOGIN ADMIN\n");

            Console.WriteLine("\tEnter Name");
            string AdminName = Console.ReadLine().ToLower();

            Console.WriteLine("\tEnter pin");
            string Adminpin = Console.ReadLine().ToLower();

            AdminView.LoginAdmin(AdminName, Adminpin);              
        }
    }
}
