using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Requests;
using Alkomentor.Domain;

namespace Alkomentor.Infrastructure.RepositoryInterfaces;

public interface IProfileRepository
{
    Task<Profile> CreateProfile(string? name, int? age, double? weight, bool? gender, Account? account);

    Task<Profile> GetProfileById(Guid profileId);
    
    Task<Profile> GetProfileByAccountId(Guid accountId);

    Task EditProfile(EditProfileDto newProfile);

    Task UpdateTokenNotify(Guid profileId, string token);
}
