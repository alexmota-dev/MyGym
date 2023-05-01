using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyGym.Models;
using MyGym.Repository;
using MyGym.Repository.Interface;
using MyGym.Services;
using System.Net;

namespace MyGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserModel model)
        {
            if(model == null)
            {
                return BadRequest(ModelState);
            }

            UserModel user = await _userRepository.GetByEmailAndPassword(model.Email, model.Password);
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
                var token = TokenService.GenerateToken(user);
                user.Password = "";

                return new
                {
                    user,
                    token
                };
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAll()
        {
            try
            {
                List<UserModel> users = await _userRepository.GetAll();
                return users;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindById(string id)
        {
            try
            {
                UserModel user = await _userRepository.GetById(id);
                return user;
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create([FromBody] UserModel user)
        {
            try
            {
                await _userRepository.Create(user);
                return user;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel user, string id)
        {
            try
            {
                await _userRepository.Update(user, id);
                return user;
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            try
            {
                await _userRepository.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - ${User.Identity.Name}";
    }
}
