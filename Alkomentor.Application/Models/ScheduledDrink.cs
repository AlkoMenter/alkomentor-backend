using Alkomentor.Contract.Dto;
using Alkomentor.Domain.Booze;

namespace Alkomentor.Application.Models;

public class ScheduledDrink
{
    public DrinkDto? Drink { get; set; }
    
    public double NeededCapacity { get; set; }
    
    public ICollection<ScheduledGulp>? ScheduledGulps { get; set; }
}