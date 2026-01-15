using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repoframework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Repository.Implementations.Data
{
    public class DatabaseSqlServer : IConfigurationDB<SqlConnection>
    {

        private readonly string _connectionString;

        public DatabaseSqlServer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public SqlConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
