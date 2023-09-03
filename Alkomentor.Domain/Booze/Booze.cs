namespace Alkomentor.Domain.Booze;

public class Booze
{
    public Guid Id { get; set; }
    
    public required Profile Profile { get; set; }

    public required DateTime StartTime { get; set; }

    public DateTime? StopTime { get; set; }

    public Stage? Stage { get; set; }

    public double CurrentProMille { get; set; }
    
    public DateTime? CurrentProMilleUpdated { get; set; }

    public ICollection<Gulp>? Gulps { get; set; }

    public ICollection<Drink>? SelectedDrinks { get; set; }
}
