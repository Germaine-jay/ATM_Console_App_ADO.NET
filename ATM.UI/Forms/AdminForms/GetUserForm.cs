using ATM.BLL.Views;
using System;


namespace ATM.UI.Forms.AdminForms
{
    public  class GetUserForm
    {
        public static void getUserForm()
        {
            Console.WriteLine("\t===> GET CUSTOMER'S DETAILS\n");

            Console.WriteLine("\tEnter Customer's Accountnumber");
            var accountnumber = Console.ReadLine();

            AdminView.GetAuser(accountnumber);
        }
    }
}
