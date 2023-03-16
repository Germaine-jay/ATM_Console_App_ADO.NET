using ATM.BLL.Implementation.AtmServices;
using System;

namespace ATM.UI.Forms.UserForms
{
    public class DepositForm
    {
        public static void Depositform()
        {
            var transactionOptions = new TransactionOptions();

            Console.WriteLine("\tEnter Your Amount");
            int amount = int.Parse(Console.ReadLine());

            Console.WriteLine("\tEnter disciption");
            string discription = Console.ReadLine();

            transactionOptions.Deposit(amount, DateTime.Now, discription);
        }
    }
}
