using Alkomentor.Api.Utils;
using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Contract.Utils;
using Alkomentor.Domain.Booze;
using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrinkController: ControllerBase
{
    private readonly IDrinkService _drinkService;

    public DrinkController(IDrinkService drinkService)
    {
        _drinkService = drinkService;
    }

    [HttpPost("createDrink")]
    public async Task<ActionResult<DrinkDto>> CreateDrink([FromBody] CreateDrinkRequest request)
    {
        var drink = await _drinkService.CreateDrink(request.Name, request.AlcoholPerGram, request.Degree);

        return Ok(Mapper.Map<Drink, DrinkDto>(drink));
    }
}
