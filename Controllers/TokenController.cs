using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenExemble.DAL;

namespace TokenExemble.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Created("",new BuiltToken().createToken());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult PageOne()
        {
            return Ok("Sayfa 1 için giriş tamam");
        }
    }
}
