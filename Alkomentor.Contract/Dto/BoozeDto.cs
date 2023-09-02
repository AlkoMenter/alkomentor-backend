namespace Alkomentor.Contract.Dto;

public class BoozeDto
{
    public Guid Id { get; set; }
    
    public required ProfileDto Profile { get; set; }

    public required DateTime StartTime { get; set; }

    public DateTime? StopTime { get; set; }

    public StageDto? Stage { get; set; }

    public double CurrentProMille { get; set; }

    public ICollection<GulpDto>? Gulps { get; set; }

    public ICollection<DrinkDto>? SelectedDrinks { get; set; }
}