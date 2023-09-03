namespace Alkomentor.Contract.Dto;

public class ScheduleDrinkDto
{
    
    public DrinkDto? Drink { get; set; }
    
    public double NeededCapacity { get; set; }
    
    public int CurrentBottleStep { get; set; }
    
    public ICollection<ScheduleGulpDto>? ScheduledGulps { get; set; }
}