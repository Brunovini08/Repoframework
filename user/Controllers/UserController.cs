using Microsoft.AspNetCore.Mvc;
using Repoframework.Repository.Interfaces;
using user.Model;

namespace user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryBase<User> _repositoryBase;
        public UserController(IRepositoryBase<User> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var sql = @"SELECT Id, Name, Age FROM Users";
            var users = await _repositoryBase.GetAll(sql);
            if (users is not null)
                return Ok(users);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User req)
        {
            var user = new User(req.Name, req.Age);
            var sql = @"INSERT INTO Users(Id, Name, Age) VALUES (@id, @name, @age)";
            await _repositoryBase.Create(new { id = user.Id, name = user.Name, age = user.Age }, sql);
            return Created();
        }
    }
}
