using Database.Abstractions.Context;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Database.Core.Context
{
    public class ApplicationDbContext : DbContext, IDatabaseContext
    {
        public DbSet<User> UsersAccounts { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringProvider.GetSqlConnection());
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}