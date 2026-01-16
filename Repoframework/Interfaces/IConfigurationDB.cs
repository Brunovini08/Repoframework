using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Repository.Interfaces
{
    public interface IConfigurationDB
    {
        public void Connection();
        public void Dispose();
        Task Create(object formatObject, string sql);
        Task Delete(object formatObject, string sql);
        Task<IEnumerable<TReturn>> GetAll<TReturn>(string sql);
        Task<TReturn> GetByIdentifier<TReturn>(object formatObject, string sql);
        Task Update(string sql, object formatObject);
    }
}
