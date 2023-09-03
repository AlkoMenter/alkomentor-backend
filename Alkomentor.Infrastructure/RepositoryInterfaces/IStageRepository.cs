using Alkomentor.Domain.Booze;

namespace Alkomentor.Infrastructure.RepositoryInterfaces;

public interface IStageRepository
{
    Task<Stage> CreateStage(string name, double minProMille, double maxProMille);
    Task<List<Stage>> GetStages();
}
