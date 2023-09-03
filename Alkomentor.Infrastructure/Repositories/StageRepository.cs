using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Alkomentor.Infrastructure.Repositories;

internal class StageRepository : IStageRepository
{
    private readonly PostgresDbContext _context;

    public StageRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<Stage> CreateStage(string name, double minProMille, double maxProMille)
    {
        var stage = _context.Stages.Add(new Stage
            {
                Name = name,
                MinProMille = minProMille,
                MaxProMille = maxProMille
            });

        await _context.SaveChangesAsync();

        return stage.Entity;
    }

    public async Task<List<Stage>> GetStages()
        => await _context.Stages.OrderBy(x => x.MinProMille).ToListAsync();
}
