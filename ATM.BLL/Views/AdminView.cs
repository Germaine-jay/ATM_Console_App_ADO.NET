using ATM.BLL.Implementation.AdminServices;
using ATM.BLL.Interfaces.AdminInterface;
using ATM.DATA.Database;
using ATM.DATA.Models;

namespace ATM.BLL.Views
{
    public class AdminView
    {
        public static void LoginAdmin(string AdminName, string Adminpin)
        {
            using (IAuthService AdminService = new LoginAdmin(new DatabaseContext()))
            {
                var username = AdminService.Login(AdminName, Adminpin);

                if (username.AdminName == null && username.AdminPin == null)
                {
                    Console.WriteLine("Admin does not exist");
                }
                else Console.WriteLine("\tlogged in\t\n Welcome {0}", username.AdminName);

            };
        }
        public static void ResetAdminPin(string AdminName, string oldpin, string newpin)
        {
            using (IAuthService AminService = new LoginAdmin(new DatabaseContext()))
            {
                var data = new AdminModelView
                {
                    AdminPin = newpin,
                };

                var Createduser = AminService.ResetPin(AdminName, oldpin, data);
                Console.WriteLine(Createduser == true ? $"Successfully Updated" : $"Not Successfully Updated");
            };
        }

        public static void CreateNewUser(string firstname, string lastname, string phonenumber, string accountpin, long accountbalance)
        {

            using (IAdminServices adminservice = new AtmAdminServices(new DatabaseContext()))
            {
                var data = new UserModelView
                {
                    FirstName = firstname,
                    LastName = lastname,
                    PhoneNumber = phonenumber,
                    AccountPin = accountpin,
                    AccountBalance = accountbalance
                };

                var Createduser = adminservice.CreateUser(data);
                Console.WriteLine(Createduser);
            };
        }

        public static void UpdateUser(string firstname, string lastname, string phonenumber)
        {

            using (IAdminServices adminservice = new AtmAdminServices(new DatabaseContext()))
            {
                var data = new UserModelView
                {
                    FirstName = firstname,
                    LastName = lastname,
                    PhoneNumber = phonenumber
                };

                var Createduser = adminservice.CreateUser(data);
                Console.WriteLine(Createduser);
            };
        }

        public static void DeleteAUser(string firstname, string lastname, string accountnumber)
        {
            using (IAdminServices adminservice = new AtmAdminServices(new DatabaseContext()))
            {
                var deleteUser = adminservice.DeleteUser(firstname, lastname, accountnumber);
                Console.WriteLine(deleteUser ? $"Successfully Deleted" : $"Not Successfully Deleted");

            }
        }

        public static void GetAuser(string accountnumber)
        {

            using (IAdminServices whatsAppService = new AtmAdminServices(new DatabaseContext()))
            {
                var user = whatsAppService.GetUser(accountnumber);

                if (user.AccountNumber == null) Console.WriteLine("Costomer does not exist");

                Console.WriteLine($"Firstname : {user.FirstName} \t Lastname : {user.LastName} \t Phone : {user.PhoneNumber} \t Accountnumber : {user.AccountNumber} \t Accountbalance{user.AccountBalance}");

            };
        }

        public static void GetAllCustomers()
        {

            using (IAdminServices whatsAppService = new AtmAdminServices(new DatabaseContext()))
            {
                var allUsers = whatsAppService.GetUsers();
                foreach (var user in allUsers)
                {
                    if (user.AccountNumber == null) Console.WriteLine("Costomer does not exist");

                    Console.WriteLine($"Firstname : {user.FirstName} \t Lastname : {user.LastName} \t Phone : {user.PhoneNumber} \t Accountnumber : {user.AccountNumber} \t Accountbalance{user.AccountBalance}");
                }
            };
        }
    }
}
