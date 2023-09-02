using Alkomentor.Application;
using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IProfileService _profileService;

    public AuthController(IAccountService accountService, IProfileService profileService)
    {
        _accountService = accountService;
        _profileService = profileService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<bool>> Login(string login, string password)
    {
        var isAccountCreated = await _accountService.CheckAuthorization(login, password);

        return isAccountCreated ? Ok() : Unauthorized();
    }
    
    [HttpPost("registration")]
    public async Task<IActionResult> Registration(string login, string password, string? name, int? age, double? weight, bool? gender)
    {
        var account = await _accountService.RegisterAccount(login, password);

        var profile = await _profileService.CreateProfile(name, age,  weight, gender, account);

        return Ok();
    }
}