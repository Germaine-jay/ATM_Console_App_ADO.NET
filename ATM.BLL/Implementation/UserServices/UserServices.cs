using ATM.BLL.Interfaces;
using ATM.BLL.Interfaces.UserInterface;
using ATM.DATA.Database;
using Microsoft.Data.SqlClient;
using ATM.BLL.Implementation.AdminServices;
using System.Data;
using ATM.BLL.Implementation.AtmServices;
using ATM.BLL.Views;

namespace ATM.BLL.Implementation.UserServices
{
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
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"UPDATE Customer SET AccountBalance = @balance WHERE AccountNumber = @AccountNumber ";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@balance",
                    Value = AtmOperations.Balance,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
                 new SqlParameter
                {
                    ParameterName = "@AccountNumber",
                    Value = AtmOperations.AccountNumber,
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

        public static void SetRecieverBalance(string accountnumber, long amount)
        {
            UserView.Reciever(accountnumber);
            using (GetBalance AminService = new GetBalance(new DatabaseContext()))
            {
                var balance = UserView.RecieverBalance += amount;
                var Reciever = AminService.UpdateBalance(accountnumber, balance);
                Console.WriteLine(Reciever == true ? $"Successfully Updated" : $"Not Successfully Updated");

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
