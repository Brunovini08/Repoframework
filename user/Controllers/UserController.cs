using Microsoft.AspNetCore.Mvc;
using Repoframework.Repository.Enum;
using Repoframework.Repository.Interfaces;
using User.API.Model;
using Users = User.API.Model.User;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryUser _repositoryBase;
        public UserController(IRepositoryUser repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var sql = @"SELECT Id, Name, Age FROM Users";
            var users = await _repositoryBase.GetAll<Users>(sql);
            if (users is not null && users.Count() > 0)
                return Ok(users);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Users req)
        {
            var user = new Users(req.Name, req.Age);
            var sql = @"INSERT INTO Users(Id, Name, Age) VALUES (@id, @name, @age)";
            await _repositoryBase.Create(new { id = user.Id, name = user.Name, age = user.Age }, sql);
            return Created();
        }
    }
}
