using Microsoft.AspNetCore.Mvc;
using Repoframework.Repository.Enum;
using Repoframework.Repository.Interfaces;
using user.Model;

namespace user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfigurationDB _db;
        private readonly IFactoryDatabase _factory;
        public UserController(IConfiguration configuration)
        {
            _db = _factory.CreateConnection(ETypeDatabase.SqlServer, configuration.GetConnectionString("SqlServer").ToString());
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var sql = @"SELECT Id, Name, Age FROM Users";
            var users = await _db.GetAll<User>(sql);
            if (users is not null)
                return Ok(users);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User req)
        {
            var user = new User(req.Name, req.Age);
            var sql = @"INSERT INTO Users(Id, Name, Age) VALUES (@id, @name, @age)";
            await _db.Create(new { id = user.Id, name = user.Name, age = user.Age }, sql);
            return Created();
        }
    }
}
