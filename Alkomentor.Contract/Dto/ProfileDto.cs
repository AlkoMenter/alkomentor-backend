namespace Alkomentor.Contract.Dto;

public class ProfileDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public double? Weight { get; set; }

    // false - male, true - female
    public bool? Gender { get; set; }
}