using System.Threading.Tasks;

namespace User.API.Model
{
    public interface IRepositoryUser
    {
        Task Create(object formatObject, string sql);
        Task<IEnumerable<TReturn>> GetAll<TReturn>(string sql);
    }
}
