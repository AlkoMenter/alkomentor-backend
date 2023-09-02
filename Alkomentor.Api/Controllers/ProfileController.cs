using Alkomentor.Application;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet("getInfo")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetInfo(Guid userId)
    {
        var profileInfo = await _profileService.GetProfile(userId);

        return profileInfo is not null ? Ok(Mapper.Map<Profile, ProfileDto>(profileInfo)) : NotFound();
    }

    [HttpPost("editProfile")]
    public ActionResult EditProfile([FromBody]EditProfileRequest request)
    {
        return Ok();
    }
}