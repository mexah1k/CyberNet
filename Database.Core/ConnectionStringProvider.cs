using System.IO;
using Microsoft.Extensions.Configuration;

namespace Data.Core
{
    public static class ConnectionStringProvider
    {
        public static string GetSqlConnection()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Directory.GetCurrentDirectory()))
                .AddJsonFile("db_connection.json")
                .Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}