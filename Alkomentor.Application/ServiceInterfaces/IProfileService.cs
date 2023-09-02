using Alkomentor.Domain;

namespace Alkomentor.Application;

public interface IProfileService
{
    Task<Profile> CreateProfile(string? name, int? age, double? weight, bool? gender, Account account);

    Task<Profile?> GetProfile(Guid userId);
}
