using ATM.BLL.Interfaces;
using ATM.BLL.Interfaces.UserInterface;
using ATM.DATA.Database;
using Microsoft.Data.SqlClient;
using ATM.BLL.Implementation.AdminServices;
using System.Data;
using ATM.BLL.Implementation.AtmServices;
using ATM.BLL.Views;
using ATM.DATA.Models;

namespace ATM.BLL.Implementation.UserServices
{
    public class GetBalance : IUserServices
    {
        private readonly DatabaseContext _dbcontext;
        private bool _disposed;

        UserModelView user = new UserModelView();

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

        public UserModelView GetUser(string accountnumber)
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"SELECT Customer.FirstName, Customer.LastName,Customer.Mobile, Customer.AccountNumber, Customer.AccountBalance FROM Customer  WHERE AccountNumber = @AccountNumber";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@AccountNumber",
                    Value = accountnumber,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }
            });

            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    user.FirstName = dataReader["FirstName"].ToString();
                    user.LastName = dataReader["LastName"].ToString();
                    user.PhoneNumber = dataReader["Mobile"].ToString();
                    user.AccountNumber = dataReader["AccountNumber"].ToString();
                    user.AccountBalance = Convert.ToInt64(dataReader["AccountBalance"]);
                }
            }
            return user;
        }

        public static void SetRecieverBalance(string accountnumber, long amount)
        {
            using (GetBalance recieverService = new GetBalance(new DatabaseContext()))
            {
                var reciever = recieverService.GetUser(accountnumber);

                var balance = reciever.AccountBalance += amount;
                var Reciever = recieverService.UpdateBalance(accountnumber, balance);
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
