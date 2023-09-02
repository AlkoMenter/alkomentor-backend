using Alkomentor.Api.Contracts.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoozeController : ControllerBase
{
    [HttpGet("getActiveBooze")]
    public ActionResult<BoozeDto> GetActiveBooze()
    {
        return Ok();
    }
    
    [HttpPost("createBooze")]
    public ActionResult CreateBooze(int boozeDegree, int[] alcType)
    {
        return Ok();
    }
    
    [HttpGet("historyBoozes")]
    public ActionResult HistoryBoozes()
    {
        return Ok();
    }
    
    [HttpGet("getBooze")]
    public ActionResult GetBooze(int idBooze)
    {
        return Ok();
    }
    
    [HttpGet("getNextDrink")]
    public ActionResult GetNextDrink()
    {
        return Ok();
    }
    
    [HttpPost("addDrink")]
    public ActionResult AddDrink(int alcType, int volumeDrink)
    {
        return Ok();
    }
}