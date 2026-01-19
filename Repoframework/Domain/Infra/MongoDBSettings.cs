using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Domain.Infra
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
