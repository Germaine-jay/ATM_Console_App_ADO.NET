using ATM.DATA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using ATM.DATA.Database;
using Microsoft.Data.SqlClient;
using ATM.BLL.Interfaces.AdminInterface;
using System.Reflection;

namespace ATM.BLL.Implementation.AdminServices
{
    public class AtmAdminServices : IAdminServices
    {
        private readonly DatabaseContext _dbcontext;
        private bool _disposed;
        public AtmAdminServices(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public long CreateUser(UserModelView user)
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"INSERT INTO Customer (FirstName, LastName, Mobile, AccountPin, AccountBalance) " +
                $"VALUES(@Firstname, @Lastname, @PhoneNumber, @AccountPin, @AccountBalance); SELECT CAST(SCOPE_IDENTITY() AS BIGINT)";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Firstname",
                    Value = user.FirstName,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 30

                },
                new SqlParameter
                {
                    ParameterName = "@Lastname",
                    Value = user.LastName,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 30

                },
                new SqlParameter
                {
                    ParameterName = "@PhoneNumber",
                    Value = user.PhoneNumber,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
                new SqlParameter
                {
                    ParameterName = "@AccountPin",
                    Value = user.AccountPin,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
                new SqlParameter
                {
                    ParameterName = "@AccountBalance",
                    Value = user.AccountBalance,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                }

            });

            long AccountNumber = (long)sqlCommand.ExecuteScalar();
            return AccountNumber;
        }

        public bool UpdateUser(string username, UserModelView user)
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"UPDATE Customer SET FirstName = @Firstname, LastName = @Lastname, PhoneNumber = @PhoneNumber  WHERE AccountNumber = @AccountNumber";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Firstname",
                    Value = user.FirstName,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 30

                },
                new SqlParameter
                {
                    ParameterName = "@Lastname",
                    Value = user.LastName,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 30

                },
                new SqlParameter
                {
                    ParameterName = "@PhoneNumber",
                    Value = user.PhoneNumber,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
            });

            var result = sqlCommand.ExecuteNonQuery();
            return (result == 0) ? false : true;
        }

        public bool DeleteUser(string firstname, string lastname, string accountnumber)
        {
            SqlConnection sqlConn = _dbcontext.OpenConnection();

            string deleteQuery = $"DELETE FROM Customer WHERE FirstName = @Firstname AND LastName = @lastname AND AccountNumber = @accountnumber";
            using SqlCommand command = new SqlCommand(deleteQuery, sqlConn);

            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Firstname",
                    Value = firstname,

                },
                new SqlParameter
                {
                    ParameterName = "@lastname",
                    Value = lastname,

                },
                 new SqlParameter
                {
                    ParameterName = "@accountnumber",
                    Value = accountnumber,
                }
            });
            var result = command.ExecuteNonQuery();
            return result != 0? false: true;

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

            UserModelView user = new UserModelView();
            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    
                    user.FirstName = dataReader["FirstName"].ToString();
                    user.LastName = dataReader["LastName"].ToString();
                    user.PhoneNumber = dataReader["Mobile"].ToString();
                    user.AccountNumber = dataReader["AccountNumber"].ToString();
                    user.AccountBalance =Convert.ToInt64( dataReader["AccountBalance"]);
                }
            }
            return user;
        }

        public IEnumerable<UserModelView> GetUsers()
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"SELECT Customer.FirstName, Customer.LastName, Customer.Mobile, Customer.AccountNumber, Customer.AccountBalance FROM Customer";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

      
            List<UserModelView> user = new List<UserModelView>();
            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    user.Add(new UserModelView()
                    {
                        FirstName = dataReader["FirstName"].ToString(),
                        LastName = dataReader["LastName"].ToString(),
                        PhoneNumber = dataReader["Mobile"].ToString(),
                        AccountNumber = dataReader["AccountNumber"].ToString(),
                        AccountBalance = Convert.ToInt64(dataReader["AccountBalance"])

                    });
                }

            }
            return user;
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
