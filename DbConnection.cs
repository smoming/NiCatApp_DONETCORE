using System;
using MySql.Data.MySqlClient;

namespace NiCatApp_DONETCORE
{
    public class DbConnection : IDisposable
    {
        public MySqlConnection Connection { get; }

        public DbConnection(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}