using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repoframework.Repository.Interfaces;
using Repoframework.Repository.Utils.settings;
using System.Data;

namespace Repoframework.Repository.Implementations.Data.SqlServer
{
    public class DatabaseSqlServer : IConfigurationDB
    {
        private SqlConnection? _connection;
        private string _connectionString;

        public DatabaseSqlServer(IOptions<DatabaseOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public IDbConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
        }

        public IDbConnection GetConnection() => _connection;
    }
}
