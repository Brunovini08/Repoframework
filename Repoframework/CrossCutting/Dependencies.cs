using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Repoframework.Domain.Infra;
using Repoframework.Domain.Interfaces;
using Repoframework.Infra.Implementations.Data.MongoDB;

namespace Repoframework.CrossCutting
{
    public class Dependencies
    {
        public static IServiceCollection Add(IServiceCollection services, Action<MongoDBSettings> action)
        {
            var options = new MongoDBSettings();
            action(options);

            services.AddScoped(typeof(IRepositoryBase<>), typeof(Repositorybase<>));
            services.AddSingleton<IMongoClient,  MongoClient>();
            services.AddSingleton<IDatabaseMongoDB, DatabaseMongoDB>();
            return services;
        }
    }
}
