namespace Alkomentor.Domain.Booze;

public class Gulp
{
    public Guid Id { get; set; }

    public required Booze Booze { get; set; }

    public double Size { get; set; }

    public required Drink Drink { get; set; }

    public required DateTime GulpTime { get; set; }
}
