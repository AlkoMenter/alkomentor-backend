
using Alkomentor.Domain;
using Microsoft.EntityFrameworkCore;

namespace Alkomentor.Infrastructure;

internal class AccountRepository : IAccountRepository
{
    private readonly PostgresDbContext _context;

    public AccountRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<Account> CreateAccount(string login, string password)
    {
        var account = _context.Accounts.Add(new Account 
            {
                Login = login,
                Password = password,
                CreateDate = DateTime.Now.ToUniversalTime()
            });
        
        await _context.SaveChangesAsync();

        return account.Entity;
    }

    public async Task<Account?> GetAccount(Guid? id, string? login, string? password)
    {
        var query = _context.Accounts.AsNoTracking();

        if (id is not null)
            query = query.Where(x => x.Id == id);

        if (login is not null)
            query = query.Where(x => x.Login == login);

        if (password is not null)
            query = query.Where(x => x.Password == password);

        return await query.FirstOrDefaultAsync();
    }
}
