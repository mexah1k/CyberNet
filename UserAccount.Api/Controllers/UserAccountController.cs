using Database.Abstractions.Repositories.UnitOfWork;
using Database.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
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
    }
}