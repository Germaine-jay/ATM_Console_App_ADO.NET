using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.DATA.Database
{
    public class CreateDatabase : IDisposable
    {
        private bool _disposed;
        public static string? ConnectionString { get; set; }
        public static void Createdb(string servername, string dbname)
        {

            bool databaseExists = false;
            string connectionString = $"Server={servername};Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                string checkDatabaseQuery = $"SELECT db_id('{dbname}')";
                SqlCommand check = new SqlCommand(checkDatabaseQuery, connection);

                var checks = check.ExecuteScalar();

                if (checks != null && checks != DBNull.Value) databaseExists = true;

                if (databaseExists)
                {
                    Console.WriteLine($"Database '{dbname}' already exists.");
                }
                else
                {
                    string createDatabaseQuery = $"CREATE DATABASE {dbname}";
                    SqlCommand command = new SqlCommand(createDatabaseQuery, connection);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Successfully created '{dbname}' database");
                    ConnectionString = (@$"Data Source={servername};Initial Catalog={dbname};Integrated Security=True; TrustServerCertificate=True;");
                    connection.Close();
                }
            }

        }

        protected virtual void Dispose(bool disposing)
        {

            if (_disposed)return;
            
            if (disposing)Dispose();        

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
