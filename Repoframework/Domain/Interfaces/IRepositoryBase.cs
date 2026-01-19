using MongoDB.Driver;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Repoframework.Domain.Interfaces
{
    public interface IRepositoryBase<TDocument> 
    {
        Task InsertOneAsync(TDocument document);
        Task InsertManyAsync(ICollection<TDocument> documents);
        Task<IEnumerable<TDocument>> FindAsync();
        Task<IAsyncCursor<TDocument>> FindOneAsync(Expression<Func<TDocument, bool>> filter);
        Task ReplaceAsync(Expression<Func<TDocument, bool>> filter, TDocument document);
        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filter);
        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filter);
    }
}
