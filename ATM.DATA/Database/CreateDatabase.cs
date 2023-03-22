using Microsoft.Data.SqlClient;


namespace ATM.DATA.Database
{
    public class CreateDatabase : IDisposable
    {
        private bool _disposed;
        public static string? ConnectionString { get; set; }
        public static void Createdb(string servername, string dbname)
        {

            bool databaseExists = false;
            string connectionString = $"Server={servername};Database=AtmAppDatabase;Trusted_Connection=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                string checkDatabaseQuery = $"SELECT db_id('AtmAppDatabase')";
                SqlCommand check = new SqlCommand(checkDatabaseQuery, connection);

                var checks = check.ExecuteScalar();

                if (checks != null && checks != DBNull.Value) databaseExists = true;

                if (databaseExists)
                {
                    Console.WriteLine($"Database '{dbname}' already exists.");
                }
                else
                {
                    string createDatabaseQuery = $"CREATE DATABASE AtmAppDatabase ";
                    SqlCommand command = new SqlCommand(createDatabaseQuery, connection);
                    command.ExecuteNonQuery();

                    Console.WriteLine($"Successfully created '{dbname}' database");
                    ConnectionString = (@$"Data Source={servername};Initial Catalog=AtmAppDatabase;Integrated Security=True; TrustServerCertificate=True;");
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
