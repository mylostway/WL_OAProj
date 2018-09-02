using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Chloe.Infrastructure;
using MySql.Data.MySqlClient;

namespace Data.dal.Chloe
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        private string m_connectionString = "";

        public MySqlConnectionFactory(string connectionStr)
        {
            m_connectionString = connectionStr;
        }

        public IDbConnection CreateConnection()
        {
            MySqlConnection conn = new MySqlConnection(this.m_connectionString);
            return conn;
        }
    }
}
