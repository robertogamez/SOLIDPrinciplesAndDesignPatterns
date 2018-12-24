using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractFactory.Core
{
    public class SqlClientFactory : IDatabaseFactory
    {
        public DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection();
        }

        public DbParameter GetParameter()
        {
            return new SqlParameter();
        }
    }
}
