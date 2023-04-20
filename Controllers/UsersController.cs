using ManagementSystem.Models;
using ManagementSystem.Repositories.Interfaces;
using ManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepositorie _usersRepositories;
        public UsersController(IUsersRepositorie usersRepositories)
        {
            _usersRepositories = usersRepositories;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        { 
            List<UserModel> users = await _usersRepositories.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById([FromRoute] int id)
        {
            var userById = await _usersRepositories.GetUserById(id);
            return userById == null ? BadRequest("Usuario não encontrado") : Ok(userById);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] CreateUserViewModel userModel)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var user = new UserModel
            {
                Name = userModel.Name,
                Email = userModel.Email,
            };

            await _usersRepositories.AddUser(user);
            return Created($"api/Users/{user.Id}", user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, [FromRoute] int id)
        {
            var user = await _usersRepositories.GetUserById(id);

            if (user == null)
                return BadRequest("Usuario não encontrado");

            user.Name = userModel.Name;
            user.Email = userModel.Email;

            await _usersRepositories.UpdateUser(user);
            return Ok(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveUser([FromRoute] int id)
        {
            var user = await _usersRepositories.GetUserById(id);

            if (user == null)
                return BadRequest("Usuario não encontrado");
        
            bool hasRemove = await _usersRepositories.RemoveUser(user);
            return hasRemove ? NoContent() : BadRequest();
        }
    }
}