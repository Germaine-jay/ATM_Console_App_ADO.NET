using ATM.BLL.Interfaces.UserInterface;
using ATM.DATA.Database;
using ATM.DATA.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ATM.BLL.Implementation.UserServices
{
    internal class UserAuthService
    {
    }
    public class AuthCustomer : IUserAuthService
    {
        private readonly DatabaseContext _dbcontext;
        private bool _disposed;
        public AuthCustomer(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public UserModelView LoginCustomer(string accountnumber, string pin)
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"SELECT Account.AccountNumber, Account.AccountBalance, Account.AccountPin FROM Customer WHERE AccountNumber = @AccountNumber and AccountPin = @AccountPin";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Accountpin",
                    Value = pin,
                },
                new SqlParameter
                {
                    ParameterName = "@AccountNumber",
                    Value = accountnumber,
                },
            });

            UserModelView Customer = new UserModelView();
            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Customer.AccountNumber = dataReader["AccountNumber"].ToString();
                    Customer.AccountBalance = Convert.ToInt64(dataReader["AccountBalance"]);
                    Customer.AccountPin = dataReader["AccountPin"].ToString();
                }
            }
            return Customer;
        }

        public bool ResetPin(string? userame, string? oldpin, UserModelView user)
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"UPDATE Customer SET AccountPin = @AccountPin WHERE AccountNumber = @AccountNumber AND AccountPin = @accountpin";

            if (user.AccountNumber == userame && user.AccountPin == oldpin) ;

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@accountpin",
                    Value = user.AccountPin,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
                 new SqlParameter
                {
                    ParameterName = "@AccountNumber",
                    Value = user.AccountNumber,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }
            });

            var result = sqlCommand.ExecuteNonQuery();
            return result == 0 ? false : true;
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
