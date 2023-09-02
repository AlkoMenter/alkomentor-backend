using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public ActionResult<string> Login(string login, string password)
    {
        return Ok("token");
    }
    
    [HttpPost("registration")]
    public ActionResult<string> Login(string login, string password, string name, int weight, bool gender)
    {
        return Ok("done");
    }
}