using Alkomentor.Domain.Booze;

namespace Alkomentor.Infrastructure.RepositoryInterfaces;

public interface IBoozeRepository
{
    Task<Booze> CreateBooze(Guid profileId, DateTime startTime, DateTime? stopTime, Guid? stageId, double currentProMille, Guid[]? selectedDrinkIds);

    Task<Booze?> GetBooze(Guid boozeId);

    Task SetCurrentProMille(Guid boozeId, double proMille);

    Task<Gulp?> CreateGulp(Guid boozeId, double Size, Guid drinkId, DateTime gulpTime);
}
