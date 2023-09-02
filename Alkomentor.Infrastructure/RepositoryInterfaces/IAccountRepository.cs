using Alkomentor.Domain;

namespace Alkomentor.Infrastructure.RepositoryInterfaces;

public interface IAccountRepository
{
    Task<Account> CreateAccount(string login, string password);

    Task<Account?> GetAccount(Guid? id, string? login, string? password);
}
