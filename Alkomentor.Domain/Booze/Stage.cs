namespace Alkomentor.Domain.Booze;

public class Stage
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public double MinProMille { get; set; }

    public double MaxProMille { get; set; }
}
