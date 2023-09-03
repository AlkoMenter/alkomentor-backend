using Alkomentor.Contract.Dto;
using Alkomentor.Domain;

namespace Alkomentor.Application.ServiceInterfaces;

public interface IProfileService
{
    Task<Profile> CreateProfile(string? name, int? age, double? weight, bool? gender, Account account);

    Task<Profile> GetProfile(Guid profileId);

    Task EditProfile(EditProfileDto newProfile);

    Task UpdateNotifyToken(Guid profileId, string token);
}
