using ATM.BLL.Implementation.UserServices;
using ATM.BLL.Implementation.AtmServices;
using ATM.DATA.Database;
using ATM.DATA.Models;
using System;
using ATM.BLL.Interfaces.UserInterface;
using ATM.BLL.Implementation.AdminServices;
using ATM.BLL.Interfaces.AdminInterface;

namespace ATM.BLL.Views
{
    public class UserView
    {
        public static long RecieverBalance;
        public static string RecieverAccount;

        public static void LoginCustomer(string accountnumber, string pin)
        {
            using (AuthCustomer authcustomer = new AuthCustomer(new DatabaseContext()))
            {
                var user = authcustomer.LoginCustomer(accountnumber, pin);

                if (user.AccountNumber == null && user.AccountPin == null)
                    Console.WriteLine("does not exist");
                else Console.WriteLine("logged in\n Welcome {0}", user.AccountBalance);

                //AuthCustomer cus = new AuthCustomer(new DatabaseContext());
                var account = new AtmServices(user.AccountBalance, user.AccountNumber);
                Console.WriteLine($"Account {user.AccountNumber} with balance {user.AccountBalance}");
                //account.Deposit(200, DateTime.Now, "first installment");

                //Console.WriteLine("Balance left:- {0}", account.Balance);

            };
        }
        public static void ResetUserPin(string accntnum, string oldpin, string newpin)
        {

            using (IUserAuthService userService = new AuthCustomer(new DatabaseContext()))
            {
                var data = new UserModelView
                {
                    AccountPin = newpin,
                };

                var Createduser = userService.ResetPin(accntnum, oldpin, data);
                Console.WriteLine(Createduser == true ? $"Successfully Updated your pin" : $"Not Successfully Updated your pin");

            };
        }

        public static void Reciever(string accountnumber)
        {

            using (IAdminServices whatsAppService = new AtmAdminServices(new DatabaseContext()))
            {
                var user = whatsAppService.GetUser(accountnumber);

                if (user.AccountNumber == null) Console.WriteLine("Costomer does not exist");

                RecieverBalance = user.AccountBalance;
                RecieverAccount = user.AccountNumber;
            };
        }

    }
}
