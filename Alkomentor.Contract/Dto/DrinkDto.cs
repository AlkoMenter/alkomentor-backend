namespace Alkomentor.Contract.Dto;

public class DrinkDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public double AlcoholPerGram { get; set; }

    public double? Degree { get; set; }
    
    public double Dosage { get; set; }
}
