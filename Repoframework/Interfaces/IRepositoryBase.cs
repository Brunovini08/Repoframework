using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Repoframework.Repository.Interfaces
{
    public interface IRepositoryBase<TReturn>
    {
        Task Create(object formatObject, string sql);
        Task Delete(object formatObject, string sql);
        Task<IEnumerable<TReturn>> GetAll(string sql);
        Task<TReturn> GetByIdentifier(object formatObject, string sql);
        Task Update(string sql, object formatObject);
    }
}
