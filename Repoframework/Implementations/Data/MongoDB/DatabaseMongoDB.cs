using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repoframework.Repository.Interfaces;
using Repoframework.Repository.Utils.settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Repository.Implementations.Data.MongoDB
{
    public class DatabaseMongoDB
    {
        private readonly MongoClient _client;
        private IMongoDatabase _mongoDatabase;
        private readonly IOptions<MongoDBSettings> _settings;
        public DatabaseMongoDB(IOptions<MongoDBSettings> settings)
        {
            _settings = settings;
            _client = new MongoClient(_settings.Value.ConnectionString);
        }
        public void Connection()
        {
            _mongoDatabase = _client.GetDatabase(_settings.Value.DatabaseName);
        }

        public void Dispose()
        {
            _mongoDatabase = null;
        }

        public async Task Create<T>(IMongoCollection<T> collection, T model)
        {
            var mongoCollection = _mongoDatabase.GetCollection<T>(collection.ToString());
            await mongoCollection.InsertOneAsync(model);
        }   

        public async Task<IEnumerable<T>> GetAll<T>(IMongoCollection<T> collection)
        {
            var mongoCollection = _mongoDatabase.GetCollection<T>(collection.ToString());
            var results = await mongoCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<T> GetByIdentifier<T>(IMongoCollection<T> collection, FilterDefinition<T> filter)
        {
            var mongoCollection = _mongoDatabase.GetCollection<T>(collection.ToString());
            var result = await mongoCollection.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task Update<T>(IMongoCollection<T> collection, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var mongoCollection = _mongoDatabase.GetCollection<T>(collection.ToString());
            await mongoCollection.UpdateOneAsync(filter, update);
        }

        public async Task Delete<T>(IMongoCollection<T> collection, FilterDefinition<T> filter)
        {
            var mongoCollection = _mongoDatabase.GetCollection<T>(collection.ToString());
            await mongoCollection.DeleteOneAsync(filter);
        }
    }
}
