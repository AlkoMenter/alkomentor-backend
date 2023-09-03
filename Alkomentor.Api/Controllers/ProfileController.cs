using Alkomentor.Api.Utils;
using Alkomentor.Application.ServiceInterfaces;
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

        return Ok(Mapper.Map<Profile, ProfileDto>(profileInfo));
    }

    [HttpPost("editProfile")]
    public async Task<ActionResult> EditProfile([FromBody]EditProfileRequest request)
    {
        await _profileService.EditProfile(Mapper.Map<EditProfileRequest, EditProfileDto>(request)!);

        return Ok();
    }

    [HttpPost("updateNotifyToken")]
    public async Task<ActionResult> UpdateNotifyToken([FromBody]UpdateNotifyTokenRequest request)
    {
        await _profileService.UpdateNotifyToken(request.ProfileId, request.NotifyToken);

        return Ok();
    }
}