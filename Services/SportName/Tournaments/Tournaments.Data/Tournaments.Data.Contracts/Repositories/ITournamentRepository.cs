﻿using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Repositories
{
    public interface ITournamentRepository : IDisposable
    {
        Task Create(Tournament tournament);

        Task Delete(int id);

        Task<Tournament> Get(int id);

        Task<PagedList<Tournament>> Get(PagingParameter paging, TournamentFilter filter);

        Task<PagedList<Team>> GetTeams(int tournamentId, PagingParameter paging);

        Task<PagedList<Series>> GetSeries(int tournamentId, PagingParameter paging);
    }
}