using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ATM.DATA.Database
{
    public class DatabaseContext : IDisposable
    {
        private readonly string? _ConnString;
        private bool _disposed = false;
        private SqlConnection _dbConnection = null;

        public DatabaseContext() : this(CreateDatabase.ConnectionString)
        {

        }
        public DatabaseContext(string dbcontext)
        {
            _ConnString = dbcontext;
        }

        public SqlConnection OpenConnection()
        {
            _dbConnection = new SqlConnection(_ConnString);
            _dbConnection.Open();
            return _dbConnection;
        }

        public void CloseConnection()
        {
            if (_dbConnection?.State != ConnectionState.Closed)
                _dbConnection?.Close();
        }

        public void Dispose(bool disposing)
        {
            if (disposing) _dbConnection.Dispose();
            if (_disposed) return;

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
