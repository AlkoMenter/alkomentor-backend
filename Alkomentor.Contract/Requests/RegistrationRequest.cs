namespace Alkomentor.Contract.Requests;

public class RegistrationRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
    public double? Weight { get; set; }
    public bool? Gender { get; set; }
}