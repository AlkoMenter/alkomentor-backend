namespace Alkomentor.Contract.Dto;

public class BoozeScheduleDto
{
    public ICollection<ScheduleDrinkDto>? ScheduledDrinks { get; set; }
}