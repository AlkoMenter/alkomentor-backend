using Alkomentor.Domain.Booze;

namespace Alkomentor.Application.ServiceInterfaces;

public interface IStageService
{
    Task<Stage> CreateStage(string name, double minProMille, double maxProMille);
    Task<List<Stage>> GetStages();
}
