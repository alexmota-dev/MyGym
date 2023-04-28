using Microsoft.AspNetCore.Mvc;
using MyGym.Models;
using MyGym.Repository;

namespace MyGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAll()
        {
            return await _userRepository.GetAll();
        }
    }
}
