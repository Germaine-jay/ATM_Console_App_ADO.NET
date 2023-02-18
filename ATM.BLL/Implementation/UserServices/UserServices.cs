using ATM.BLL.Interfaces;
using ATM.BLL.Interfaces.UserInterface;
using ATM.DATA.Database;
using Microsoft.Data.SqlClient;
using ATM.BLL.Implementation.AdminServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.BLL.Implementation.AtmServices;


namespace ATM.BLL.Implementation.UserServices
{
    /*internal class UserServices
    {
    }*/

    /*public class Signal
    {
        public static void SetBalance(string accountnumber, long balance)
        {
            using (GetBalance AminService = new GetBalance(new DatabaseContext()))
            {
                var Createduser = AminService.UpdateBalance(accountnumber, balance);
                Console.WriteLine(Createduser == true ? $"Successfully Updated" : $"Not Successfully Updated");

            };
        }
    }*/
    public class GetBalance : IUserServices
    {
        private readonly DatabaseContext _dbcontext;
        private bool _disposed;
        public GetBalance(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool UpdateBalance(string accountnumber, long balance)
        {
            //AtmServices admin = new AtmServices(balance,accountnumber);

            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"UPDATE Customer SET AccountBalance = @balance WHERE AccountNumber = @AccountNumber ";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@balance",
                    Value = TransactionOptions.Balance,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                },
                 new SqlParameter
                {
                    ParameterName = "@AccountNumber",
                    Value = TransactionOptions.AccountNumber,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }
            });

            var result = sqlCommand.ExecuteNonQuery();
            return (result == 0) ? false : true;
        }

        public static void SetBalance(string accountnumber, long balance)
        {
            using (GetBalance AminService = new GetBalance(new DatabaseContext()))
            {
                var Createduser = AminService.UpdateBalance(accountnumber, balance);
                Console.WriteLine(Createduser == true ? $"Successfully Updated" : $"Not Successfully Updated");

            };
        }

        protected virtual void Dispose(bool disposing)
        {

            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbcontext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
