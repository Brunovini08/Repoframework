using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Repository.Implementations.Data.MongoDB
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public Dictionary<string, string> Collections { get; set; }
    }
}
