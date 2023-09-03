using Alkomentor.Domain;

namespace Alkomentor.Application.ServiceInterfaces;

public interface IAccountService
{
    Task<Profile?> CheckAuthorization(string login, string password);

    Task<Account> RegisterAccount(string login, string password);
}
