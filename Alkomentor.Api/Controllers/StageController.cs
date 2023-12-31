﻿using Alkomentor.Api.Utils;
using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Contract.Utils;
using Alkomentor.Domain.Booze;
using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StageController: ControllerBase
{
    private readonly IStageService _stageService;

    public StageController(IStageService stageService)
    {
        _stageService = stageService;
    }

    [HttpPost("createStage")]
    public async Task<ActionResult<StageDto>> CreateStage([FromBody] CreateStageRequest request)
    {
        var stage = await _stageService.CreateStage(request.Name, request.MinProMille, request.MaxProMille);
        return Ok(Mapper.Map<Stage, StageDto>(stage));
    }

    [HttpGet("getAllStages")]
    public async Task<ActionResult<List<StageDto>>> GetDrinks()
    {
        var drink = await _stageService.GetStages();

        return Ok(Mapper.Map<List<Stage>, List<StageDto>>(drink));
    }
}
