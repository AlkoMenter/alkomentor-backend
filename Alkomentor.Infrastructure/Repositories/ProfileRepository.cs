using Alkomentor.Contract.Requests;
using Alkomentor.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Profile?> GetProfile(Guid userId)
    {
        var user = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == userId);

        return user;
    }

    public async Task EditProfile(EditProfileRequest request)
    {
        var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Account.Id == request.AccountId);

        if (profile == null) 
            throw new KeyNotFoundException("User not found");

        await UpdateProfileAsync(profile, request);
    }

    private async Task UpdateProfileAsync(Profile profile, EditProfileRequest request)
    {
        profile.Name = request.Name;
        profile.Age = request.Age;
        profile.Weight = request.Weight;
        profile.Gender = request.Gender;
        
        _context.Profiles.Update(profile);
        await _context.SaveChangesAsync();
    }
}