using MongoDB.Driver;
using Repoframework.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repoframework.Infra.Implementations.Data.MongoDB
{
    public class Repositorybase<TDocument> : IRepositoryBase<TDocument>
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<TDocument> _collection;
        public Repositorybase(DatabaseMongoDB database, string collectionName)
        {
            _database = database.Connection();
            _collection = _database.GetCollection<TDocument>(collectionName);
        }


        public async Task DeleteManyAsync(Expression<Func<TDocument, bool>> filter)
        {
            await _collection.DeleteManyAsync<TDocument>(filter);
        }

        public async Task DeleteOneAsync(Expression<Func<TDocument, bool>> filter)
        {
            await _collection.DeleteOneAsync<TDocument>(filter);
        }

        public async Task<IEnumerable<TDocument>> FindAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public async Task InsertOneAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task UpdateAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> document)
        {
            await _collection.FindOneAndUpdateAsync(filter, document);
        }
    }
}
