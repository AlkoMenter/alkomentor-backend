using Alkomentor.Api.Utils;
using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Contract.Utils;
using Alkomentor.Domain;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ProfileDto>> Login([FromBody] LoginRequest request)
    {
        var profile = await _accountService.CheckAuthorization(request.Login, request.Password);

        if (profile is null) return Unauthorized();

        return Ok(Mapper.Map<Profile, ProfileDto>(profile));
    }

    [HttpPost("registration")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDto))]
    public async Task<IActionResult> Registration([FromBody] RegistrationRequest request)
    {
        var account = await _accountService.RegisterAccount(request.Login, request.Password);

        var profile =
            await _profileService.CreateProfile(request.Name, request.Age, request.Weight, request.Gender, account);

        return Ok(Mapper.Map<Profile, ProfileDto>(profile));
    }
}