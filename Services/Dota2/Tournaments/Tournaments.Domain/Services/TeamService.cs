using AutoMapper;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading.Tasks;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;
using Tournaments.Data.Entities;
using Tournaments.Domain.Contracts;
using Tournaments.Dtos;

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

        public async Task<PagedList<TeamDto>> Get(PagingParameter paging)
        {
            var teams = await unitOfWork.Teams.Get(paging);
            return Map(teams);
        }

        public async Task<TeamDto> Create(TeamForCreationDto playerDto)
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
            var teamCreatingDto = mapper.Map<TeamForUpdateDto>(team);

            teamPatchDto.ApplyTo(teamCreatingDto);
            mapper.Map(teamCreatingDto, team);

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

        private Team Map(TeamDto source)
        {
            return mapper.Map<Team>(source);
        }

        private Team Map(TeamForCreationDto source)
        {
            return mapper.Map<Team>(source);
        }

        private PagedList<TeamDto> Map(PagedList<Team> source)
        {
            return mapper.Map<PagedList<TeamDto>>(source);
        }
    }
}