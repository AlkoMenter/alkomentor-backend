
using Alkomentor.Domain;
using Alkomentor.Infrastructure;

namespace Alkomentor.Application;

internal class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<bool> CheckAuthorization(string login, string password)
    {
        var account = await _accountRepository.GetAccount(null, login, password);

        return account is not null;
    }

    public async Task<Account> RegisterAccount(string login, string password)
        => await _accountRepository.CreateAccount(login, password);
}
