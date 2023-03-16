using ATM.BLL.Implementation.AtmServices;
using System;

namespace ATM.UI.Forms.UserForms
{
    public class TransferForm
    {
        public static void Rechargeform()
        {
            var transactionOptions = new TransactionOptions();

            Console.WriteLine("\tEnter Your Amount");
            int amount = int.Parse(Console.ReadLine());

            Console.WriteLine("\tEnter Recipient Accountnumber");
            string account = Console.ReadLine();

            Console.WriteLine("\tEnter disciption");
            string discription = Console.ReadLine();

            transactionOptions.Transfer(amount, account, DateTime.Now, discription);
        }
    }
}
