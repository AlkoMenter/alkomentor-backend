namespace Alkomentor.Domain.Booze;

public class Drink
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public double AlcoholPerGram { get; set; }

    public double Degree { get; set; }
}
