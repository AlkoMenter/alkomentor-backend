using Alkomentor.Domain.Booze;

namespace Alkomentor.Infrastructure.RepositoryInterfaces;

public interface IBoozeRepository
{
    Task<Booze> CreateBooze(Guid profileId, DateTime startTime, DateTime? stopTime, Guid? stageId, double currentProMille, Guid[]? selectedDrinkIds);

    Task<Booze?> GetBooze(Guid boozeId);
}
