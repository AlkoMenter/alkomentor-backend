using Alkomentor.Domain;

namespace Alkomentor.Application;

public interface IAccountService
{
    Task<bool> CheckAuthorization(string login, string password);

    Task<Account> RegisterAccount(string login, string password);
}
