using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AutoLot.Dal.BulkCopy
{
    public static class ProcessBulkCopy
    {
        private const string connectionString = @"Data Source=.,5433;User Id=sa;Password=P@ssw0rd;Initial Catalog=Autolot;Encrypt=False";
        private static SqlConnection sqlConnection = null;

        
        private static void OpenConnection()
        {
            sqlConnection = new(connectionString);
            sqlConnection.Open();
        }
        private static void CloseConnection()
        {
            if (sqlConnection?.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
        public static void ExecuteBulkCopy<T>(IEnumerable<T> records, string tableName)
        {
            OpenConnection();

            using SqlConnection connection = sqlConnection;

            SqlBulkCopy bc = new(connection) { DestinationTableName = tableName };

            var reader = new ALotDataReader<T>(records.ToList(), connection, "dbo", tableName);

            try
            {
                bc.WriteToServer(reader);
            }
            catch (Exception e)
            { 
                // TODO
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
