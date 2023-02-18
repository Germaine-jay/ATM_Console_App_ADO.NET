using System;
using System.Collections.Generic;
using ATM.BLL.Views;

namespace ATM.UI.Forms.UserForms
{
    public class LoginUserForm
    {
        public static void loginCustomerForm()
        {
            Console.WriteLine("\t===> ENTER YOUR ACCOUNT NUMBER AND PIN TO LIGIN\n");

            Console.WriteLine("\tEnter Your Account Number");
            string accountnumber = Console.ReadLine();

            Console.WriteLine("\tEnter your pin");
            string pin = Console.ReadLine();

            UserView.LoginCustomer(accountnumber, pin);
        }
    }
}
