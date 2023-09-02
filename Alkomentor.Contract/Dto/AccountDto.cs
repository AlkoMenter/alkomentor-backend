namespace Alkomentor.Contract.Dto;

public class AccountDto
{
    public Guid Id { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }

    public required DateTime CreateDate { get; set; }
}
