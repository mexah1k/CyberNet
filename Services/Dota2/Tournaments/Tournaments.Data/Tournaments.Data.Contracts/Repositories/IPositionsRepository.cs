﻿using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Entities;

namespace Tournaments.Data.Contracts.Repositories
{
    public interface IPositionsRepository : IDisposable
    {
        Task<Position> Get(int id);

        Task<PagedList<Position>> Get(PagingParameter paging);
    }
}