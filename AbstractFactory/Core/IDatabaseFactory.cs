using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractFactory.Core
{
    public interface IDatabaseFactory
    {
        DbConnection GetConnection();
        DbCommand GetCommand();
        DbParameter GetParameter();
    }
}
