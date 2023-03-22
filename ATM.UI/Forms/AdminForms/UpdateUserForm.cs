using ATM.BLL.Views;
using System;


namespace ATM.UI.Forms.AdminForms
{
    public class UpdateUserForm
    {
        public static void updateUserForm()
        {
            Console.WriteLine("\t===> UPDATE CUSTOMER'S DETAILS\n");

            Console.WriteLine(" Enter FirstName");
            string? firstname = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter LastName");
            string? lastname = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter PhoneNumber");
            string? phonenumber = Console.ReadLine().ToLower();

            AdminView.UpdateUser(firstname, lastname, phonenumber);
            
        }
    }
}
