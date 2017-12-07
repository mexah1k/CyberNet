using AutoMapper;
using Database.Abstractions.Repositories.UnitOfWork;
using Database.Entities.Entities;
using Mapper.Dtos.UserAccount;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAccount.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserAccountsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserAccountsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // GET api/useraccount/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            var user = await unitOfWork.Accounts.Get(id);

            return Map(user);
        }

        // GET api/useraccount
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            var users = await unitOfWork.Accounts.Get();

            return users.Select(Map);
        }

        // POST api/useraccount
        [HttpPost]
        public async Task Post([FromBody]UserDto user)
        {
            await unitOfWork.Accounts.Add(Map(user));
        }

        // DELETE api/useraccount/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await unitOfWork.Accounts.Delete(id);
        }

        private UserDto Map(User source)
        {
            return mapper.Map<UserDto>(source);
        }

        private User Map(UserDto source)
        {
            return mapper.Map<User>(source);
        }
    }
}