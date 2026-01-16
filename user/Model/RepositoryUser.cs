using Repoframework.Repository.Implementations;
using Repoframework.Repository.Interfaces;

namespace User.API.Model
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly IRepositoryBase _repositoryBase;

        public RepositoryUser(IRepositoryBase repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Create(object formatObject, string sql)
        {
            await _repositoryBase.Create(formatObject, sql);
        }

        public async Task<IEnumerable<TReturn>> GetAll<TReturn>(string sql)
        {
            return await _repositoryBase.GetAll<TReturn>(sql);
        }
    }
}
