using Database.Abstractions.Context;
using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context.Context
{
    public class ApplicationDbContext : DbContext, IDatabaseContext
    {
        public DbSet<UserAccount> UsersAccounts { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        protected ApplicationDbContext()
        {
        }

        protected ApplicationDbContext(DbContextOptions connectionString)
            : base(connectionString)
        {
        }
    }
}