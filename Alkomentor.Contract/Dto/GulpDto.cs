namespace Alkomentor.Contract.Dto;

public class GulpDto
{
    public Guid Id { get; set; }

    public double Size { get; set; }

    public required DrinkDto Drink { get; set; }

    public required DateTime GulpTime { get; set; }
}