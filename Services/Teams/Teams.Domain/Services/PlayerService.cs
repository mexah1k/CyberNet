using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Exceptions;
using Teams.Data.Contracts.Repositories.UnitOfWork;
using Teams.Data.Entities;
using Teams.Dtos;

namespace Teams.Domain.Services
{
    public class PlayerService
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
            Throw.IfEntityNotFound(player);

            return Map(player);
        }

        public async Task<IEnumerable<PlayerDto>> Get(int teamId)
        {
            var players = await unitOfWork.Players.GetPlayersByTeam(teamId);

            return players.Select(Map);
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

        private Player Map(PlayerForCreationDto source)
        {
            return mapper.Map<Player>(source);
        }
    }
}