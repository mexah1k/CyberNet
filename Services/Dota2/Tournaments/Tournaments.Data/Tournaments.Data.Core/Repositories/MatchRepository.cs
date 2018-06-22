using Infrastructure.Exceptions;
using Infrastructure.Extensions;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Context;
using Tournaments.Data.Contracts.Repositories;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Core.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IDataContext context;

        public MatchRepository(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Match> Get(int id)
        {
            return await context.Matches
                .Include(m => m.DireTeam)
                .Include(m => m.RadiantTeam)
                .GetOrThrow(id);
        }

        public async Task<PagedList<Match>> Get(PagingParameter paging)
        {
            return await context.Matches
                .Include(m => m.DireTeam)
                .Include(m => m.RadiantTeam)
                .ToPaginatedResult(paging);
        }

        public async Task Create(Match match)
        {
            Throw.IfNull(match, nameof(match));
            await context.Matches.AddAsync(match);
        }

        public async Task Delete(int id)
        {
            var match = await Get(id);
            context.Matches.Remove(match);
        }

        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}