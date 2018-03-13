using Microsoft.EntityFrameworkCore.Design;

namespace Teams.Data.Core.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return new ApplicationDbContext();
        }

        public static void Main(string[] args)
        {
        }
    }
}