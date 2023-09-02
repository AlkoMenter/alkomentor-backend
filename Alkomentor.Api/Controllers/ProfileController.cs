using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    [HttpGet("getInfo")]
    public ActionResult GetInfo()
    {
        return Ok();
    }

    [HttpPost("editProfile")]
    public ActionResult EditProfile(string name, int weight, bool gender)
    {
        return Ok();
    }
}