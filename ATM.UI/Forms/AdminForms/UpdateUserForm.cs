using ATM.BLL.Views;
using System;


namespace ATM.UI.Forms.AdminForms
{
    public class UpdateUserForm
    {
        public static void updateUserForm()
        {
            Console.WriteLine("\t===> UPDATE CUSTOMER'S DETAILS\n");

            Console.WriteLine("\tEnter FirstName");
            string? firstname = Console.ReadLine().ToLower();

            Console.WriteLine("\tEnter LastName");
            string? lastname = Console.ReadLine().ToLower();

            Console.WriteLine("\tEnter PhoneNumber");
            string? phonenumber = Console.ReadLine().ToLower();

            AdminView.UpdateUser(firstname, lastname, phonenumber);
            
        }
    }
}
