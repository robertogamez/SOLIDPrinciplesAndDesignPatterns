using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractFactory.Core
{
    public class DatabaseHelper
    {
        private IDatabaseFactory factory;

        public DatabaseHelper(IDatabaseFactory factory)
        {
            this.factory = factory;
        }

        public DbDataReader ExecuteSelect(string query)
        {
            DbConnection cnn = factory.GetConnection();
            cnn.ConnectionString = "Server=.;Database=BethanysPieShop;Trusted_Connection=True;MultipleActiveResultSets=true";
            DbCommand cmd = factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cnn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DbDataReader ExecuteSelect(string query, DbParameter[] parameters)
        {
            DbConnection cnn = factory.GetConnection();
            cnn.ConnectionString = "Server=.;Database=BethanysPieShop;Trusted_Connection=True;MultipleActiveResultSets=true";
            DbCommand cmd = factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.AddRange(parameters);
            cnn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public int ExecuteAction(string query)
        {
            DbConnection cnn = factory.GetConnection();
            cnn.ConnectionString = "Server=.;Database=BethanysPieShop;Trusted_Connection=True;MultipleActiveResultSets=true";
            DbCommand cmd = factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cnn.Open();
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }

        public int ExecuteAction(string query, DbParameter[] parameters)
        {
            DbConnection cnn = factory.GetConnection();
            cnn.ConnectionString = "Server=.;Database=BethanysPieShop;Trusted_Connection=True;MultipleActiveResultSets=true";
            DbCommand cmd = factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.AddRange(parameters);
            cnn.Open();
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }

    }
}
