using Dapper;
using Microsoft.Data.SqlClient;
using Repoframework.Repository.Interfaces;

namespace Repoframework.Repository.Implementations.Data
{
    public class DatabaseSqlServer : IConfigurationDB
    {

        private readonly string _connectionString;
        private SqlConnection _connection;

        public DatabaseSqlServer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connection()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public void Dispose()
        {
            if (_connection is not null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        public async Task Create(object formatObject, string sql)
        {
            try
            {
                if (_connection is null)
                    throw new InvalidOperationException("Database connection is not established. Call Connection() method first.");
                await _connection.ExecuteAsync(sql, formatObject);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Delete(object formatObject, string sql)
        {
            try
            {
                if (_connection is null)
                    throw new InvalidOperationException("Database connection is not established. Call Connection() method first.");
                return _connection.ExecuteAsync(sql, formatObject);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>(string sql, object objectReturn)
        {
            try
            {
                if (_connection is null)
                    throw new InvalidOperationException("Database connection is not established. Call Connection() method first.");
                return await _connection.QueryAsync<T>(sql, objectReturn);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetByIdentifier<T>(object formatObject, string sql)
        {
            try
            {
                if (_connection is null)
                    throw new InvalidOperationException("Database connection is not established. Call Connection() method first.");
                return await _connection.QueryFirstOrDefaultAsync(sql, formatObject);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Update(string sql, object formatObject)
        {
            try
            {
                if (_connection is null)
                    throw new InvalidOperationException("Database connection is not established. Call Connection() method first.");
                return _connection.ExecuteAsync(sql, formatObject);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
