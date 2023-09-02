using Alkomentor.Domain;

namespace Alkomentor.Infrastructure;

internal class ProfileRepository : IProfileRepository
{
    private readonly PostgresDbContext _context;

    public ProfileRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<Profile> CreateProfile(string? name, int? age, double? weight, bool? gender, Account? account)
    {
        if (account is not null)
            _context.Accounts.Attach(account);
            
        var profile = _context.Add(new Profile
            {
                Name = name,
                Age = age,
                Weight = weight,
                Gender = gender,
                Account = account
            });

        await _context.SaveChangesAsync();

        return profile.Entity;
    }
}
