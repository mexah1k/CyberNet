using AutoMapper;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Filters;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;
using Tournaments.Data.Entities;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos.Player;
using Tournaments.Dtos.Team;
using Tournaments.Dtos.Tournament;

namespace Tournaments.Domain.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<TeamDto> Get(int id)
        {
            var team = await unitOfWork.Teams.Get(id);
            return Map(team);
        }

        public async Task<PagedList<TeamDto>> Get(PagingParameter paging, TeamFilter filters)
        {
            var teams = await unitOfWork.Teams.Get(paging, filters);
            return Map(teams);
        }

        public async Task<PagedList<PlayerDto>> GetPlayers(int id, PagingParameter paging)
        {
            var teamPlayers = await unitOfWork.Teams.GetPlayers(id, paging);
            return Map(teamPlayers);
        }

        public async Task<PagedList<TournamentDto>> GetTournaments(int teamId, PagingParameter paging)
        {
            var tournaments = await unitOfWork.Teams.GetTournaments(teamId, paging);
            return Map(tournaments);
        }

        public async Task<TeamDto> Create(TeamForCreateDto playerDto)
        {
            var team = Map(playerDto);

            await unitOfWork.Teams.Create(team);
            await SaveDbChangesAsync();

            return Map(team);
        }

        public async Task Delete(int id)
        {
            await unitOfWork.Players.Delete(id);
            await SaveDbChangesAsync();
        }

        public async Task Update(TeamForUpdateDto teamDto, int id)
        {
            var team = await unitOfWork.Teams.Get(id);

            mapper.Map(teamDto, team);
            await SaveDbChangesAsync();
        }

        public async Task PartialUpdate(JsonPatchDocument<TeamForUpdateDto> teamPatchDto, int id)
        {
            var team = await unitOfWork.Teams.Get(id);
            var teamForUpdateDto = mapper.Map<TeamForUpdateDto>(team);

            teamPatchDto.ApplyTo(teamForUpdateDto);
            mapper.Map(teamForUpdateDto, team);

            await SaveDbChangesAsync();
        }

        private async Task SaveDbChangesAsync()
        {
            if (!await unitOfWork.SaveChangesAsync())
                throw new Exception("Something went wrong."); // todo: move message to resource file
        }

        private TeamDto Map(Team source)
        {
            return mapper.Map<TeamDto>(source);
        }

        private Team Map(TeamForCreateDto source)
        {
            return mapper.Map<Team>(source);
        }

        private PagedList<TeamDto> Map(PagedList<Team> source)
        {
            return mapper.Map<PagedList<TeamDto>>(source);
        }

        private PagedList<PlayerDto> Map(PagedList<Player> source)
        {
            return mapper.Map<PagedList<PlayerDto>>(source);
        }

        private PagedList<TournamentDto> Map(PagedList<Tournament> source)
        {
            return mapper.Map<PagedList<TournamentDto>>(source);
        }
    }
}