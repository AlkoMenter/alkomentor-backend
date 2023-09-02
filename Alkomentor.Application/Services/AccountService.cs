
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

    public async Task<Account?> CheckAuthorization(string login, string password)
        =>  await _accountRepository.GetAccount(null, login, password);

    public async Task<Account> RegisterAccount(string login, string password)
        => await _accountRepository.CreateAccount(login, password);
}
