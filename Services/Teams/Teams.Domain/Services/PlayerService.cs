using AutoMapper;
using Infrastructure.Pagination;
using System;
using System.Threading.Tasks;
using Teams.Data.Contracts.Repositories.UnitOfWork;
using Teams.Data.Entities;
using Teams.Domain.Contracts;
using Teams.Dtos;

namespace Teams.Domain.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PlayerDto> Get(int teamId, int id)
        {
            var player = await unitOfWork.Players.GetPlayerByTeam(teamId, id);

            return Map(player);
        }

        public async Task<PagedList<PlayerDto>> Get(PagingParameter paging, int teamId)
        {
            var players = await unitOfWork.Players.GetPlayersByTeam(paging, teamId);

            return Map(players);
        }

        private async void SaveDbChangesAsync()
        {
            if (!await unitOfWork.SaveChangesAsync())
                throw new Exception("Creation failed."); // todo: move message to resource file
        }

        private PlayerDto Map(Player source)
        {
            return mapper.Map<PlayerDto>(source);
        }

        private PagedList<PlayerDto> Map(PagedList<Player> source)
        {
            return mapper.Map<PagedList<PlayerDto>>(source);
        }
    }
}