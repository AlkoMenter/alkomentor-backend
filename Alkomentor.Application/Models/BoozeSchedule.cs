using Alkomentor.Contract.Dto;
using Alkomentor.Domain.Booze;

namespace Alkomentor.Application.Models;

public class BoozeSchedule
{
    public BoozeDto? Booze { get; set; }
    
    public double NeededEtanolVolume { get; set; }

    public ICollection<ScheduledDrink>? ScheduledDrinks { get; set; }
}