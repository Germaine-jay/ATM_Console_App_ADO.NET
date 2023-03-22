using ATM.UI.Forms.AdminForms;
using ATM.UI.Forms.UserForms;


namespace ATM_App
{
    public  class StartApp
    {
        public static void Startapp()
        {

            Console.WriteLine("\t*************************************");
            Console.WriteLine("\t*      Welcome to Germane Bank      *");
            Console.WriteLine("\t*************************************");

        }

        public static void AccessOptions()
        {
            Console.WriteLine(" select option:\n \n =>1. Login Admin  \n\n =>2. Login Customer ");

            string? option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    LoginAdminForm.loginadminForm();
                    break;
                case "2":
                    Console.Clear();
                    LoginUserForm.loginCustomerForm();
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    AccessOptions();
                    break;
            }
        }
        public static void UserOptions()
        {
            Console.WriteLine(" select option:\n =>1. Reset Admin Pin  \n =>2. Create New Customer \n =>3. Update Customer Details \n");
            Console.WriteLine(" =>4. Get All Customer \\n =>5. Get A Customer \\n =>6. Delete A Customer \n" );

            string ? option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    ResetAdminPinForm.ResetadminpinForm();
                    ContinueOption();

                    break;
                case "2":
                    Console.Clear();
                    CreateNewUserForm.createNewUserForm();
                    ContinueOption();

                    break;
                case "3":
                    Console.Clear();
                    UpdateUserForm.updateUserForm();
                    ContinueOption();

                    break;
                case "4":
                    Console.Clear();
                    GetUsersForm.getAllCustomerForm();
                    ContinueOption();

                    break;
                case "5":
                    Console.Clear();
                    GetUserForm.getUserForm();
                    ContinueOption();

                    break;
                case "6":
                    Console.Clear();
                    DeleteUserForm.deleteUserForm();
                    ContinueOption();

                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    AccessOptions();
                    break;
            }
        }

        public static void TransactionOptions()
        {
            Console.WriteLine("\tSELECT TRANSACTION OPTION\n");
            Console.WriteLine(" =>1. Withdraw                  =>2. Transfer \n\n");
            Console.WriteLine(" =>3. Deposit                   =>4. Recharge\n\n");
            Console.WriteLine(" =>5. Balance Enquiry           ==>6. Reset Pin");

            bool Validate = true;

            string? tranoption = Console.ReadLine();
            switch (tranoption)
            {
                case "1":
                    Console.Clear();
                    WithdrawalForm.Withdrawal();
                    ContinueOption();
                    break;
                case "2":
                    Console.Clear();
                    TransferForm.Transferform();
                    ContinueOption();

                    break;
                case "3":
                    Console.Clear();
                    DepositForm.Depositform();
                    ContinueOption();

                    break;
                case "4":
                    Console.Clear();
                    RechargeForm.Rechargeform();
                    ContinueOption();

                    break;
                case "5":
                    Console.Clear();
                    CheckBalance.Checkbalance();
                    ContinueOption();
                    break;

                default:
                    Console.WriteLine("Invalid Option\n");
                    ContinueOption();
                    break;
            }
        }

        public static void ContinueOption()
        {
            Console.WriteLine("Do you want to carry out another transaction....y/n");

            var Option = Console.ReadLine().ToLower();
            switch (Option)
            {
                case "y":
                    AccessOptions();
                    break;
                case "n":
                    Console.WriteLine("\nTHANK YOU!");
                    break;
                default:
                    ContinueOption();
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
}
