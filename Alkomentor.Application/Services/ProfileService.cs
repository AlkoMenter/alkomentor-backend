using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Domain;
using Alkomentor.Infrastructure.RepositoryInterfaces;

namespace Alkomentor.Application.Services;

internal class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Profile> CreateProfile(string? name, int? age, double? weight, bool? gender, Account account)
        => await _profileRepository.CreateProfile(name, age, weight, gender, account);

    public async Task<Profile> GetProfile(Guid profileId)
    {
        return await _profileRepository.GetProfileById(profileId);
    }

    public async Task EditProfile(EditProfileDto newProfile)
    {
        await _profileRepository.EditProfile(newProfile);
    }

    public async Task UpdateNotifyToken(Guid profileId, string token)
    {
        await _profileRepository.UpdateTokenNotify(profileId, token);
    }
}