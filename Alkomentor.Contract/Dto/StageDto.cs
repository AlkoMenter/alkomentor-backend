namespace Alkomentor.Contract.Dto;

public class StageDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public double MinProMille { get; set; }

    public double MaxProMille { get; set; }
}
