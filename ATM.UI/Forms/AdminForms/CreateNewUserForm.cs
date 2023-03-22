using ATM.BLL.Views;
using System;

namespace ATM.UI.Forms.AdminForms
{
    public class CreateNewUserForm
    {
        public static void createNewUserForm()
        {
            Console.WriteLine("\t===> CREATE A NEW CUSTOMER'S\n");

            Console.WriteLine(" Enter FirstName");
            string firstname = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter LastName");
            string lastname = Console.ReadLine().ToLower();

            Console.WriteLine(" Enter PhoneNumber");
            var phonenumber = Console.ReadLine().ToString();

            Console.WriteLine(" Enter PhoneNumber");
            var accountpin = Console.ReadLine().ToString();

            Console.WriteLine(" Enter PhoneNumber");
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
