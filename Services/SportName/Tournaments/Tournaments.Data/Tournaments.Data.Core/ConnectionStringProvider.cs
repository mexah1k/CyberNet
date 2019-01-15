using Microsoft.Extensions.Configuration;
using System.IO;

namespace Tournaments.Data.Core
{
    public static class ConnectionStringProvider
    {
        public static string GetSqlConnection()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())))
                .AddJsonFile("db_connection.json")
                .Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}