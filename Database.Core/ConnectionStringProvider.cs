using Microsoft.Extensions.Configuration;
using System.IO;

namespace Database.Core
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