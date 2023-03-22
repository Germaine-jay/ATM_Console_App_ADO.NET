using ATM.DATA.Database;
using ATM.DATA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ATM.BLL.Interfaces.AdminInterface;

namespace ATM.BLL.Implementation.AdminServices
{
    public class LoginAdmin : IAuthService
    {
        private readonly DatabaseContext _dbcontext;
        private bool _disposed;
        public LoginAdmin(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public AdminModelView Login(string username, string pin)
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"SELECT Admins.AdminName, Admins.AminPin FROM Admins WHERE AminPin = @Adminpin and AdminName = @Adminname ";

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Adminpin",
                    Value = pin,
                },
                new SqlParameter
                {
                    ParameterName = "@Adminname",
                    Value = username,
                }
            });

            AdminModelView admin = new AdminModelView();
            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    admin.AdminName = dataReader["AdminName"].ToString();
                    admin.AdminPin = dataReader["AminPin"].ToString();
                }
            }
            return admin;
        }

        public bool ResetPin(string AdminName, string AdminPin, AdminModelView user)
        {
            SqlConnection sqlconn = _dbcontext.OpenConnection();

            string sqlquery = $"UPDATE Admins SET AminPin = @Adminpin WHERE AdminName = @AdminName";

            if (user.AdminName == AdminName && user.AdminPin == AdminPin) ;

            using SqlCommand sqlCommand = new SqlCommand(sqlquery, sqlconn);

            sqlCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Adminpin",
                    Value = user.AdminPin,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
                 new SqlParameter
                {
                    ParameterName = "@AdminName",
                    Value = AdminName,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }
            });

            var result = sqlCommand.ExecuteNonQuery();
            return result == 0 ? false : true;
        }

        public void LogOut()
        {
            throw new NotImplementedException();
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
