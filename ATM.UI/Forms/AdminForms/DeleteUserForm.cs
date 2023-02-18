using ATM.BLL.Views;
using System;

namespace ATM.UI.Forms.AdminForms
{
    public  class DeleteUserForm
    {
        public static void deleteUserForm()
        {
            Console.WriteLine("\t===> DELETE CUSTOMER\n");

            Console.WriteLine("\tEnter FirstName");
            string? firstname = Console.ReadLine().ToLower();

            Console.WriteLine("\tEnter LastName");
            string? lastname = Console.ReadLine().ToLower();

            Console.WriteLine("\tEnter LastName");
            string? accountnumber = Console.ReadLine().ToLower();

            AdminView.DeleteAUser(firstname, lastname, accountnumber);
        }
    }
}
