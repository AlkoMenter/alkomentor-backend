using Alkomentor.Application.ServiceInterfaces;
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

    public async Task<Profile?> GetProfile(Guid userId)
    {
        return await _profileRepository.GetProfile(userId);
    }

    public async Task EditProfile(EditProfileRequest request)
    {
        await _profileRepository.EditProfile(request);
    }
}