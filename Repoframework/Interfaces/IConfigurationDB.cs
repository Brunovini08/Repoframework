using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repoframework.Repository.Interfaces
{
    public interface IConfigurationDB
    {
        public IDbConnection Connection();
        public IDbConnection GetConnection();
        public void Dispose();
    }
}
