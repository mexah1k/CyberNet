using Database.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Abstractions.Context
{
    public interface IDatabaseContext
    {
        DbSet<UserAccount> UsersAccounts { get; set; }
        DbSet<UserToken> UserTokens { get; set; }
    }
}