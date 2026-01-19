using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repoframework.Domain.Infra;
using Repoframework.Domain.Interfaces;
namespace Repoframework.Infra.Implementations.Data.MongoDB
{
    public class DatabaseMongoDB : IDatabaseMongoDB
    {
        private readonly IOptions<MongoDBSettings> _settings;
        public DatabaseMongoDB(IOptions<MongoDBSettings> settings)
        {
            _settings = settings;
        }
        public IMongoDatabase Connection()
        {
            var client = new MongoClient(_settings.Value.ConnectionString);
            return client.GetDatabase(_settings.Value.DatabaseName);
        }
    }
}
