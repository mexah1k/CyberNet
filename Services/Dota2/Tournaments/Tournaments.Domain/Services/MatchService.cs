using AutoMapper;
using Tournaments.Data.Contracts.Repositories.UnitOfWork;

namespace Tournaments.Domain.Services
{
    public class MatchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MatchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


    }
}