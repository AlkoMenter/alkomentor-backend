using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.RepositoryInterfaces;

namespace Alkomentor.Application.Services;

internal class BoozeService : IBoozeService
{
    private readonly IBoozeRepository _boozeRepository;

    public BoozeService(IBoozeRepository boozeRepository)
    {
        _boozeRepository = boozeRepository;
    }

    public async Task<Booze> CreateBooze(Guid profileId, DateTime startTime, DateTime? stopTime, Guid? stageId, double currentProMille, Guid[]? selectedDrinkIds)
        => await _boozeRepository.CreateBooze(profileId, startTime, stopTime, stageId, currentProMille, selectedDrinkIds);
}
