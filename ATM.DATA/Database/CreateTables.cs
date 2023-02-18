using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.DATA.Database
{
    public class CreateTable
    {
        public static string? ConnectionServer = CreateDatabase.ConnectionString;

        public static void createtable(SqlCommand command, string TableName, SqlConnection connection)
        {

            bool tableExists = false;
            using (SqlCommand command2 = new SqlCommand($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{TableName}'", connection))
            {
                int checktable = (int)command2.ExecuteScalar();
                if (checktable > 0) tableExists = true;
                if (tableExists == false) Console.WriteLine($" {TableName} Table created successfully.");
                else Console.WriteLine($"{TableName} Table not successfully created.\nTable may already exist.");
                Console.WriteLine();
            }
            if (!tableExists)
            {
                command.ExecuteNonQuery();
            }

        }
        public static void createTables()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionServer))
            {
                connection.Open();

                string createUserTableQuery = "CREATE TABLE Customer (AccountNumber INT NOT NULL IDENTITY(2071512832, 15),FirstName VARCHAR(30) NOT NULL,LastName VARCHAR(30) NOT NULL,Mobile VARCHAR(50) NOT NULL UNIQUE,AccountPin VARCHAR(50) NOT NULL,AccountBalance INT DEFAULT 0)";
                using (SqlCommand command = new SqlCommand(createUserTableQuery, connection))
                {
                    string? TableName = "Customer";
                    createtable(command, TableName, connection);
                }

                string createChatTableQuery = "CREATE TABLE Admins (AdminId INT NOT NULL PRIMARY KEY IDENTITY(1,1),AdminName VARCHAR(30) NOT NULL,AminPin VARCHAR(30) NOT NULL,AdminMobile VARCHAR(50) NOT NULL UNIQUE)";
                using (SqlCommand command = new SqlCommand(createChatTableQuery, connection))
                {
                    string? TableName = "Admins";
                    createtable(command, TableName, connection);
                }

                string createUserChatTableQuery = "CREATE TABLE Transactions (TransactionId INT NOT NULL PRIMARY KEY IDENTITY(1,1),Type VARCHAR(50) NOT NULL,Date VARCHAR(60) NOT NULL,Description VARCHAR(60) NOT NULL,Amount VARCHAR(50) NULL)";
                using (SqlCommand command = new SqlCommand(createUserChatTableQuery, connection))
                {
                    string? TableName = "Transactions";
                    createtable(command, TableName, connection);
                }
                
                connection.Close();
            }
        }

    }
}
