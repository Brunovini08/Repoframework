using Repoframework.Repository.Enum;

namespace Repoframework.Repository.Interfaces
{
    public interface IFactoryDatabase
    {
        public IConfigurationDB CreateConnection(ETypeDatabase eTypeDatabase, string? connectionString);
    }
}