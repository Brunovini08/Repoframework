using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repoframework.Repository.Implementations.Data.SqlServer;
using Repoframework.Repository.Interfaces;
using Repoframework.Repository.Utils.settings;

namespace Repoframework.Repository.Utils.extensions
{
    public static class RepoFrameworkExtensions
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services, IConfiguration configuration, Action<DatabaseOptions> action)
        {
            var options = new DatabaseOptions();
            action(options);

            services.AddScoped<IConfigurationDB, DatabaseSqlServer>();
            services.Configure<DatabaseOptions>(action);
            services.Scan(scan => scan
                .FromAssemblyOf<IRepositoryBase>()
                    .AddClasses(classes => classes.AssignableTo<IRepositoryBase>())
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                .FromAssemblyOf<IConfigurationDB>()
                    .AddClasses(classes => classes.AssignableTo<IConfigurationDB>())
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
            );

            return services;
        }
    }
}
