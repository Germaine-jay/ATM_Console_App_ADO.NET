using ATM.BLL.Views;
using System;

namespace ATM.UI.Forms.AdminForms
{
    public  class DeleteUserForm
    {
        public static void deleteUserForm()
        {
            Console.WriteLine("\t===> DELETE CUSTOMER\n");

            Console.WriteLine(" Enter FirstName");
            string? firstname = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter LastName");
            string? lastname = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter LastName");
            string? accountnumber = Console.ReadLine().ToLower();

            AdminView.DeleteAUser(firstname, lastname, accountnumber);
        }
    }
}
