using Dapper;
using Microsoft.Data.SqlClient;
using Repoframework.Repository.Interfaces;
using System.Data;

namespace Repoframework.Repository.Implementations
{
    public class RepositoryBase : IRepositoryBase
    {
        private IDbConnection _connection;
        public RepositoryBase(IConfigurationDB connection) 
        {
            _connection = connection.Connection();
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

        public async Task<IEnumerable<T>> GetAll<T>(string sql)
        {
            try
            {
                if (_connection is null)
                    throw new InvalidOperationException("Database connection is not established. Call Connection() method first.");
                return await _connection.QueryAsync<T>(sql);
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
