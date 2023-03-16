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
            int amount = int.Parse(Console.ReadLine());

            Console.WriteLine("\tEnter disciption");
            string discription = Console.ReadLine();

            transactionOptions.Recharge(amount, DateTime.Now, discription);
        }
    }
}
