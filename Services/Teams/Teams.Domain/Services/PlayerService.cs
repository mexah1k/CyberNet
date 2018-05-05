using AutoMapper;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<PlayerDto> Get(int id)
        {
            var player = await unitOfWork.Players.Get(id);
            return Map(player);
        }

        public async Task<PagedList<PlayerDto>> Get(PagingParameter paging)
        {
            var players = await unitOfWork.Players.Get(paging);
            return Map(players);
        }

        public async Task<PlayerDto> Create(PlayerForCreationDto playerDto)
        {
            var player = Map(playerDto);

            await unitOfWork.Players.Create(player);
            await SaveDbChangesAsync();

            return Map(player);
        }

        public async Task Delete(int id)
        {
            await unitOfWork.Players.Delete(id);
            await SaveDbChangesAsync();
        }

        // TODO: Upserting could be implemented (create if not exist)
        public async Task PartialUpdate(JsonPatchDocument<PlayerForUpdateDto> playerPatchDto, int playerId, int? positionId, int? teamId)
        {
            var player = await unitOfWork.Players.Get(playerId);
            var playerCreatingDto = mapper.Map<PlayerForUpdateDto>(player);

            playerPatchDto.ApplyTo(playerCreatingDto);
            mapper.Map(playerCreatingDto, player);

            if (positionId.HasValue)
                player.Position = await unitOfWork.Positions.Get(positionId.Value);

            if (teamId.HasValue)
                player.Team = await unitOfWork.Teams.Get(teamId.Value);

            await SaveDbChangesAsync();
        }

        // TODO: Upserting could be implemented (create if not exist)
        public async Task Update(PlayerForUpdateDto playerDto, int playerId, int positionId, int? teamId)
        {
            var player = await unitOfWork.Players.Get(playerId);

            mapper.Map(playerDto, player);
            player.Position = await unitOfWork.Positions.Get(positionId);

            if (teamId.HasValue)
                player.Team = await unitOfWork.Teams.Get(teamId.Value);

            await SaveDbChangesAsync();
        }

        private async Task SaveDbChangesAsync()
        {
            if (!await unitOfWork.SaveChangesAsync())
                throw new Exception("Something went wrong."); // todo: move message to resource file
        }

        private PlayerDto Map(Player source)
        {
            return mapper.Map<PlayerDto>(source);
        }

        private Player Map(PlayerForCreationDto source)
        {
            return mapper.Map<Player>(source);
        }

        private PagedList<PlayerDto> Map(PagedList<Player> source)
        {
            return mapper.Map<PagedList<PlayerDto>>(source);
        }
    }
}