using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Domain.Interfaces
{
    public interface IDatabaseMongoDB
    {
        IMongoDatabase Connection();
    }
}
