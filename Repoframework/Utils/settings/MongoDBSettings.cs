using System;
using System.Collections.Generic;
using System.Text;

<<<<<<<< HEAD:Repoframework/Domain/Infra/MongoDBSettings.cs
namespace Repoframework.Domain.Infra
========
namespace Repoframework.Repository.Utils.settings
>>>>>>>> 4a13afa63a924564d91abf1a59e416a4d07d2f54:Repoframework/Utils/settings/MongoDBSettings.cs
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
