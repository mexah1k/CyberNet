using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Database.Abstractions.Context
{
    public interface IDatabaseContext
    {
        DbSet<User> UsersAccounts { get; set; }
        DbSet<UserToken> UserTokens { get; set; }

        Task<int> SaveChangesAsync();
    }
}