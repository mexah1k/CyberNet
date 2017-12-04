using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Database.Core.Context
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