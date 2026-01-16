using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repoframework.Repository.Interfaces
{
    public interface IConfigurationDB
    {
        public void Connection();
        public void Dispose();
    }
}
