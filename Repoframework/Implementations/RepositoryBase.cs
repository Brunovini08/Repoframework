using Dapper;
using Microsoft.Data.SqlClient;
using Repoframework.Repository.Interfaces;

namespace Repoframework.Repository.Implementations
{
    public class RepositoryBase<TReturn>: IRepositoryBase<TReturn>
    {

        private readonly SqlConnection _connection;

        public RepositoryBase(IConfigurationDB<SqlConnection> database)
        {
            _connection = database.Connection();
        }

        public async Task Create(object formatObject, string sql)
        {
            try
            {
                await _connection.ExecuteAsync(sql, formatObject);
            } catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(object formatObject, string sql)
        {
            try
            {
                await _connection.ExecuteAsync(sql, formatObject);
;            } catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TReturn>> GetAll(string sql)
        {
            try
            {
                return await _connection.QueryAsync<TReturn>(sql);
            } catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TReturn> GetByIdentifier(object formatObject, string sql)
        {
            try
            {
                return await _connection.QueryFirstOrDefaultAsync<TReturn>(sql);
            } catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(string sql, object formatObject)
        {
            try
            {
                await _connection.ExecuteAsync(sql, formatObject);
            } catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
