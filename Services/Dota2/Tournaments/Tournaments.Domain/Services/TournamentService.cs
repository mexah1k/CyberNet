using AutoMapper;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;
using Tournaments.Data.Entities;
using Tournaments.Data.Entities.HelperTables;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Series;
using Tournaments.Dtos.Team;
using Tournaments.Dtos.Tournament;

namespace Tournaments.Domain.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TournamentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<TournamentDto> Get(int id)
        {
            var tournament = await unitOfWork.Tournament.Get(id);
            return Map(tournament);
        }

        public async Task<PagedList<TournamentDto>> Get(PagingParameter paging, TournamentFilter filter)
        {
            var tournaments = await unitOfWork.Tournament.Get(paging, filter);
            return Map(tournaments);
        }

        public async Task<PagedList<TeamDto>> GetTeams(int id, PagingParameter paging)
        {
            var teams = await unitOfWork.Tournament.GetTeams(id, paging);
            return Map(teams);
        }

        public async Task<PagedList<SeriesDto>> GetSeries(int id, PagingParameter paging)
        {
            var series = await unitOfWork.Tournament.GetSeries(id, paging);
            return Map(series);
        }

        public async Task<TournamentDto> Create(TournamentForCreateDto tournamentDto)
        {
            var tournament = Map(tournamentDto);

            await unitOfWork.Tournament.Create(tournament);
            await SaveDbChangesAsync();

            return Map(tournament);
        }

        public async Task Delete(int id)
        {
            await unitOfWork.Tournament.Delete(id);
            await SaveDbChangesAsync();
        }

        public async Task Update(TournamentForUpdateDto tournamentDto, int id)
        {
            var tournament = await unitOfWork.Tournament.Get(id);

            mapper.Map(tournamentDto, tournament);
            await SaveDbChangesAsync();
        }

        public async Task PartialUpdate(JsonPatchDocument<TournamentForUpdateDto> tournamentPatchDto, int id)
        {
            var tournament = await unitOfWork.Tournament.Get(id);
            var tournamentForUpdateDto = mapper.Map<TournamentForUpdateDto>(tournament);

            tournamentPatchDto.ApplyTo(tournamentForUpdateDto);
            mapper.Map(tournamentForUpdateDto, tournament);

            await SaveDbChangesAsync();
        }

        public async Task AddTeams(IEnumerable<int> teamIds, int id)
        {
            var tournament = await unitOfWork.Tournament.Get(id);
            var teams = await unitOfWork.Teams.Get(teamIds);

            foreach (var team in teams)
            {
                tournament.TeamTournament.Add(new TeamTournament
                {
                    Team = team,
                    Tournament = tournament
                });
            }

            await SaveDbChangesAsync();
        }

        private async Task SaveDbChangesAsync()
        {
            if (!await unitOfWork.SaveChangesAsync())
                throw new Exception("Something went wrong."); // todo: move message to resource file
        }

        private TournamentDto Map(Tournament source)
        {
            return mapper.Map<TournamentDto>(source);
        }

        private Tournament Map(TournamentDto source)
        {
            return mapper.Map<Tournament>(source);
        }

        private Tournament Map(TournamentForCreateDto source)
        {
            return mapper.Map<Tournament>(source);
        }

        private PagedList<TournamentDto> Map(PagedList<Tournament> source)
        {
            return mapper.Map<PagedList<TournamentDto>>(source);
        }

        private PagedList<TeamDto> Map(PagedList<Team> source)
        {
            return mapper.Map<PagedList<TeamDto>>(source);
        }

        private PagedList<SeriesDto> Map(PagedList<Series> source)
        {
            return mapper.Map<PagedList<SeriesDto>>(source);
        }
    }
}