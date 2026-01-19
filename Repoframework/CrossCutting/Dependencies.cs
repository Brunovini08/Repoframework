using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Repoframework.Domain.Infra;
using Repoframework.Domain.Interfaces;
using Repoframework.Infra.Implementations.Data.MongoDB;

namespace Repoframework.CrossCutting
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, Action<MongoDBSettings> action)
        {
            var options = new MongoDBSettings();
            action(options);
            services.Configure<MongoDBSettings>(action);
            services.AddScoped(typeof(IRepositoryBase<>), typeof(Repositorybase<>));
            services.AddSingleton<IMongoClient,  MongoClient>();
            services.AddScoped<IDatabaseMongoDB, DatabaseMongoDB>();
            return services;
        }
    }
}
