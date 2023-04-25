using Microsoft.AspNetCore.Mvc;
using MyGym.Models;

namespace MyGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public ActionResult<Task<List<UserModel>>> FindAll()
        {
            return Ok();
        }
    }
}
