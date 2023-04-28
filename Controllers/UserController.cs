using Microsoft.AspNetCore.Mvc;
using MyGym.Models;
using MyGym.Repository;
using MyGym.Repository.Interface;

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

        [HttpGet]
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
    }
}
