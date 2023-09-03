using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Contract.Utils;
using Alkomentor.Domain.Booze;
using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoozeController : ControllerBase
{
    private readonly IBoozeService _boozeService;

    public BoozeController(IBoozeService boozeService)
    {
        _boozeService = boozeService;
    }

    [HttpPost("createBooze")]
    public async Task<ActionResult<BoozeDto>> CreateBooze([FromBody] CreateBoozeRequest request)
    {
        var booze = await _boozeService.CreateBooze(request.ProfileId, request.StartTime, request.StopTime,
            request.StageId, request.CurrentProMille, request.SelectedDrinkIds);
        
        return Ok(Mapper.Map<Booze, BoozeDto>(booze));
    }

    [HttpGet("getBooze")]
    public async Task<ActionResult<BoozeDto>> GetBooze(Guid boozeId)
    {
        return Ok(await _boozeService.GetBooze(boozeId));
    }

    [HttpPost("drink")]
    public async Task<ActionResult<BoozeDto>> Drink([FromBody]BoozeDrinkRequest request)
    {
        return Ok(await _boozeService.Drink(request.BoozeId, request.DrinkId));
    }
}