using ATM.BLL.Views;
using System;


namespace ATM.UI.Forms.AdminForms
{
    public class ResetAdminPinForm
    {
        public static void ResetadminpinForm()
        {
            Console.WriteLine("\t===> RESET ADMIN PINCODE\n");

            Console.WriteLine(" Enter Name");
            string? AdminName = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter old pin");
            string? oldpin = Console.ReadLine();

            Console.WriteLine(" Enter new pin");
            string newpin = Console.ReadLine().ToString();

            AdminView.ResetAdminPin(AdminName, oldpin, newpin);
        }

    }
}
