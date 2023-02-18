using System;
using System.Text;
using System.Threading.Tasks;

namespace ATM.BLL.Implementation.AtmServices
{
    /*public class AtmServices
    {
    }*/
    public class AtmServices
    {
        public static long AccountBalance { get; set; }
        public static string? AccountNumber { get; set; }

        public AtmServices(long accountbalance, string accountnumber)
        {
            AccountBalance = accountbalance;
            AccountNumber = accountnumber;
        }

    }
}
