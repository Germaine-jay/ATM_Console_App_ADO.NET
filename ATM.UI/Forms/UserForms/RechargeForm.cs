using ATM.BLL.Implementation.AtmServices;
using System;

namespace ATM.UI.Forms.UserForms
{
    public class RechargeForm
    {
        public static void Rechargeform()
        {
            var transactionOptions = new TransactionOptions();

            Console.WriteLine("\tEnter Your Amount");
            var amount = Console.ReadLine();

            Console.WriteLine("\tEnter disciption");
            string description = Console.ReadLine();

            var limit = 20000;
            if (long.Parse(amount) <= 1 || long.TryParse(amount.ToString(), out _) == false)
            {
                Console.WriteLine("Inalid Amount: Amount must be greater than zero");
            }

            if (long.Parse(amount) > limit)
            {
                Console.WriteLine("Amount must be less than a #20000");
            }

            if (AtmServices.AccountBalance - int.Parse(amount) <= 1)
            {
                Console.WriteLine("Unable to compplete Transation: Your balance is low");
            }

            transactionOptions.Recharge(int.Parse(amount), DateTime.Now, description);
        }
    }
}
