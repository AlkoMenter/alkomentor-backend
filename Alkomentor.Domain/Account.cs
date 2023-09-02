namespace Alkomentor.Domain;

public class Account
{
    public Guid Id { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }

    public required DateTime CreateDate { get; set; }

    public string? NotifyToken { get; set; } = "";
}
