namespace Alkomentor.Domain;

public class Drink
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public double Alc { get; set; }

    public double Dosage { get; set; }
}
