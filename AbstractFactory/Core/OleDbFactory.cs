using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace AbstractFactory.Core
{
    public class OleDbFactory : IDatabaseFactory
    {
        public DbCommand GetCommand()
        {
            return new SqliteCommand();
        }

        public DbConnection GetConnection()
        {
            return new SqliteConnection();
        }

        public DbParameter GetParameter()
        {
            return new SqliteParameter();
        }
    }
}
