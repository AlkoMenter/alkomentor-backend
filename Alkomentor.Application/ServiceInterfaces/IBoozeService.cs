using Alkomentor.Contract.Dto;
using Alkomentor.Domain.Booze;

namespace Alkomentor.Application.ServiceInterfaces;

public interface IBoozeService
{
    Task<Booze> CreateBooze(Guid profileId, DateTime startTime, DateTime? stopTime,
        Guid? stageId, double currentProMille, Guid[]? selectedDrinkIds);

    Task<BoozeDto?> GetBooze(Guid boozeId);

    Task<BoozeDto?> Drink(Guid boozeId, Guid drinkId);
}
