using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Domain;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Alkomentor.Infrastructure.Repositories;

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

    public async Task<Profile> GetProfileById(Guid profileId)
    {
        var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == profileId);
        if (profile is null)
            throw new KeyNotFoundException();
        
        return profile;
    }

    public async Task<Profile> GetProfileByAccountId(Guid accountId)
    {
        var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Account.Id == accountId);
        if (profile is null)
            throw new KeyNotFoundException();
        
        return profile;
    }

    public async Task EditProfile(EditProfileDto newProfile)
    {
        var profile = await GetProfileById(newProfile.Id);

        await UpdateProfileAsync(profile, newProfile);
    }

    public async Task UpdateTokenNotify(Guid profileId, string token)
    {
        var profile = await GetProfileById(profileId);
        profile.NotifyToken = token;
        
        _context.Profiles.Update(profile);
        await _context.SaveChangesAsync();
    }

    private async Task UpdateProfileAsync(Profile profile, EditProfileDto newProfile)
    {
        profile.Name = newProfile.Name;
        profile.Age = newProfile.Age;
        profile.Weight = newProfile.Weight;
        profile.Gender = newProfile.Gender;
        if (!string.IsNullOrEmpty(newProfile.NotifyToken))
            profile.NotifyToken = newProfile.NotifyToken;
        
        _context.Profiles.Update(profile);
        await _context.SaveChangesAsync();
    }
}