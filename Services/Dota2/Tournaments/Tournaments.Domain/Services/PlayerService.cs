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
        public async Task PartialUpdate(JsonPatchDocument<PlayerForUpdateDto> playerPatchDto, int id)
        {
            var player = await unitOfWork.Players.Get(id);
            var playerForUpdateDto = mapper.Map<PlayerForUpdateDto>(player);

            playerPatchDto.ApplyTo(playerForUpdateDto);
            mapper.Map(playerForUpdateDto, player);

            await UpdatePlayerPosition(playerForUpdateDto, player);
            await UpdatePlayerTeam(playerForUpdateDto, player);

            await SaveDbChangesAsync();
        }

        // TODO: Upserting could be implemented (create if not exist)
        public async Task Update(PlayerForUpdateDto playerForUpdateDto, int id)
        {
            var player = await unitOfWork.Players.Get(id);

            mapper.Map(playerForUpdateDto, player);

            if (playerForUpdateDto.PositionId.HasValue)
                player.Position = await unitOfWork.Positions.Get(playerForUpdateDto.PositionId.Value);

            await UpdatePlayerPosition(playerForUpdateDto, player);
            await UpdatePlayerTeam(playerForUpdateDto, player);

            await SaveDbChangesAsync();
        }

        private async Task UpdatePlayerTeam(PlayerForUpdateDto playerDto, Player player)
        {
            if (playerDto.TeamId.HasValue)
                player.Team = await unitOfWork.Teams.Get(playerDto.TeamId.Value);
        }

        private async Task SaveDbChangesAsync()
        {
            if (!await unitOfWork.SaveChangesAsync())
                throw new Exception("Something went wrong."); // todo: move message to resource file
        }

        private async Task UpdatePlayerPosition(PlayerForUpdateDto playerForUpdateDto, Player player)
        {
            if (playerForUpdateDto.PositionId.HasValue)
                player.Position = await unitOfWork.Positions.Get(playerForUpdateDto.PositionId.Value);
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