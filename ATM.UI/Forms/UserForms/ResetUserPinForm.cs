using System;

using ATM.BLL.Views;

namespace ATM.UI.Forms.UserForms
{
    public class ResetUserPinForm
    {
        public static void resetUserPinForm()
        {
            
            Console.WriteLine("Enter Name");
            string accntnum = Console.ReadLine();

            Console.WriteLine("\nEnter old pin");
            string oldpin = Console.ReadLine();

            Console.WriteLine("\nEnter new pin");
            var newpin = Console.ReadLine().ToString();

            UserView.ResetUserPin(accntnum, oldpin, newpin);
        }
    }
}
