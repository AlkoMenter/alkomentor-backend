using Alkomentor.Api.Utils;
using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
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

    // [HttpGet("getActiveBooze")]
    // public ActionResult<BoozeDto> GetActiveBooze()
    // {
    //     return Ok();
    // }
    
    [HttpPost("createBooze")]
    public async Task<ActionResult<BoozeDto>> CreateBooze([FromBody] CreateBoozeRequest request)
    {
        var booze = await _boozeService.CreateBooze(request.ProfileId, request.StartTime, request.StopTime,
            request.StageId, request.CurrentProMille, request.SelectedDrinkIds);
        
        return Ok(Mapper.Map<Booze, BoozeDto>(booze));
    }
    
    // [HttpGet("historyBoozes")]
    // public ActionResult HistoryBoozes()
    // {
    //     return Ok();
    // }
    //
    // [HttpGet("getBooze")]
    // public ActionResult GetBooze(int idBooze)
    // {
    //     return Ok();
    // }
    //
    // [HttpGet("getNextDrink")]
    // public ActionResult GetNextDrink()
    // {
    //     return Ok();
    // }
    //
    // [HttpPost("addDrink")]
    // public ActionResult AddDrink(int alcType, int volumeDrink)
    // {
    //     return Ok();
    // }
}