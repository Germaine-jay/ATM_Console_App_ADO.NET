using ATM.BLL.Implementation.AtmServices;
using System;

namespace ATM.UI.Forms.UserForms
{
    public class WithdrawalForm
    {
        public static void Withdrawalform()
        {
            var transactionOptions = new TransactionOptions();

            Console.WriteLine("\tEnter Your Amount");
            var amount = Console.ReadLine();

            Console.WriteLine("\tEnter disciption");
            string discription = Console.ReadLine();

            var limit = 1000000;
            if (long.Parse(amount) <= 1 || long.TryParse(amount.ToString(), out _) == false)
            {
                Console.WriteLine("Inalid Amount: Amount must be greater than zero");
            }

            if (long.Parse(amount) > limit)
            {
                Console.WriteLine("Amount must be less than a million");
            }

            if (AtmServices.AccountBalance - int.Parse(amount) <= 1)
            {
                Console.WriteLine("Unable to compplete Transation: Your balance is low");
            }

            transactionOptions.Deposit(int.Parse(amount), DateTime.Now, discription);
        }

    }
}
