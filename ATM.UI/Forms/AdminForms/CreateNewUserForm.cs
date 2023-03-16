using ATM.BLL.Views;
using System;

namespace ATM.UI.Forms.AdminForms
{
    public class CreateNewUserForm
    {
        public static void createNewUserForm()
        {
            Console.WriteLine("\t===> CREATE A NEW CUSTOMER'S\n");

            Console.WriteLine("\tEnter FirstName");
            string firstname = Console.ReadLine().ToLower();

            Console.WriteLine("\tEnter LastName");
            string lastname = Console.ReadLine().ToLower();

            Console.WriteLine("\tEnter PhoneNumber");
            var phonenumber = Console.ReadLine().ToString();

            Console.WriteLine("\tEnter PhoneNumber");
            var accountpin = Console.ReadLine().ToString();

            Console.WriteLine("\tEnter PhoneNumber");
            long accountbalance = long.Parse(Console.ReadLine());

            if(accountbalance != 0 )
            {
                Console.WriteLine("Account balance should not be #0 for a strart");
            }
            if (accountpin != "0000")
            {
                Console.WriteLine("Account pin should not be for a start");
            }

            AdminView.CreateNewUser(firstname, lastname, phonenumber, accountpin, accountbalance);          
               
            }
        }
}
