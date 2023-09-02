using Alkomentor.Contract.Requests;
using Alkomentor.Domain;

namespace Alkomentor.Application.ServiceInterfaces;

public interface IProfileService
{
    Task<Profile> CreateProfile(string? name, int? age, double? weight, bool? gender, Account account);

    Task<Profile?> GetProfile(Guid userId);

    Task EditProfile(EditProfileRequest request);
}
