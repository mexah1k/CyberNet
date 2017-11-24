using Database.Abstractions.Context;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Database.Core.Context
{
    public class ApplicationDbContext : DbContext, IDatabaseContext
    {
        public DbSet<UserAccount> UsersAccounts { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        protected ApplicationDbContext()
        {
        }

        protected ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}