using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.RepositoryInterfaces;

namespace Alkomentor.Application.Services;

internal class StageService : IStageService
{
    private readonly IStageRepository _stageRepository;

    public StageService(IStageRepository stageRepository)
    {
        _stageRepository = stageRepository;
    }

    public async Task<Stage> CreateStage(string name, double minProMille, double maxProMille)
        => await _stageRepository.CreateStage(name, minProMille, maxProMille);
}
