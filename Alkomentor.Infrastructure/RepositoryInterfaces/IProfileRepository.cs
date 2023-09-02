using Alkomentor.Domain;

namespace Alkomentor.Infrastructure;

public interface IProfileRepository
{
    Task<Profile> CreateProfile(string? name, int? age, double? weight, bool? gender, Account? account);
}
