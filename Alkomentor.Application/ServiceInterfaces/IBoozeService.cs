using Alkomentor.Application.Models;
using Alkomentor.Domain.Booze;

namespace Alkomentor.Application.ServiceInterfaces;

public interface IBoozeService
{
    Task<Booze> CreateBooze(Guid profileId, DateTime startTime, DateTime? stopTime,
        Guid? stageId, double currentProMille, Guid[]? selectedDrinkIds);

    Task<BoozeSchedule?> CalculateBoozeSchedule(Guid boozeId);
}
