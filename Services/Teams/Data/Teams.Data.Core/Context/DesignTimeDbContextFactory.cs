using Microsoft.EntityFrameworkCore.Design;

namespace Teams.Data.Core.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext();
        }

        public static void Main(string[] args)
        {
        }
    }
}