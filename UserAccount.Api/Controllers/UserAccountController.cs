using Database.Abstractions.Repositories.UnitOfWork;
using Database.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserAccount.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserAccountController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserAccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/useraccount/5
        [HttpGet("{id}")]
        public Task<User> Get(int id)
        {
            return unitOfWork.Accounts.Get(id);
        }

        // GET api/useraccount
        [HttpGet]
        public Task<IEnumerable<User>> Get()
        {
            return unitOfWork.Accounts.Get();
        }

        // POST api/useraccount
        [HttpPost]
        public async Task Post([FromBody]User user)
        {
            await unitOfWork.Accounts.Add(user);
        }

        // DELETE api/useraccount/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await unitOfWork.Accounts.Delete(id);
        }
    }
}