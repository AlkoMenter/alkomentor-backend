using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Domain;
using Alkomentor.Infrastructure.RepositoryInterfaces;

namespace Alkomentor.Application.Services;

internal class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IProfileRepository _profileRepository;

    public AccountService(IAccountRepository accountRepository, IProfileRepository profileRepository)
    {
        _accountRepository = accountRepository;
        _profileRepository = profileRepository;
    }

    public async Task<Profile?> CheckAuthorization(string login, string password)
    {
        var account = await _accountRepository.GetAccount(null, login, password);
        if (account is null)
            return null;

        var profile = await _profileRepository.GetProfileByAccountId(account.Id);
        
        return profile;
    }

    public async Task<Account> RegisterAccount(string login, string password)
        => await _accountRepository.CreateAccount(login, password);
}
