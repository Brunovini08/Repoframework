using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Repoframework.Repository.Enum;
using Repoframework.Repository.Implementations.Data.MongoDB;
using Repoframework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Repository.Implementations.Data
{
    public class FactoryDatabase : IFactoryDatabase
    {
        private readonly IOptions<MongoDBSettings>? _settings;
        public FactoryDatabase(IOptions<MongoDBSettings>? settings)
        {
            _settings = settings;
        }
        public IConfigurationDB CreateConnection(ETypeDatabase eTypeDatabase, string? connectionString)
        {
            return eTypeDatabase switch
            {
                ETypeDatabase.SqlServer => new DatabaseSqlServer(
                    connectionString is not null ? connectionString : 
                        throw new Exception("You need give me a connectionString")),
            };
        }
    }
}
