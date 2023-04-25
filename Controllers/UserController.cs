using Microsoft.AspNetCore.Mvc;
using MyGym.Models;

namespace MyGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> FindAll()
        {
            return Ok();
        }
    }
}
