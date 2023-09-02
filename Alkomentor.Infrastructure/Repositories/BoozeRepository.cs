using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Alkomentor.Infrastructure.Repositories;

internal class BoozeRepository : IBoozeRepository
{
    private readonly PostgresDbContext _context;

    public BoozeRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<Booze> CreateBooze(Guid profileId, DateTime startTime, DateTime? stopTime, Guid? stageId, double currentProMille, Guid[]? selectedDrinkIds)
    {
        var profile = await _context.Profiles.FirstAsync(x => x.Id == profileId);

        Drink[]? selectedDrinks = null;

        if (selectedDrinkIds is not null)
            selectedDrinks = await _context.Drinks
                .Where(x => selectedDrinkIds.Contains(x.Id))
                .ToArrayAsync();

        var stage = await _context.Stages.FirstAsync(x => x.Id == stageId);

        var booze = _context.Boozes.Add(new Booze 
            {
                Profile = profile,
                SelectedDrinks = selectedDrinks,
                StartTime = startTime,
                StopTime = stopTime,
                Stage = stage,
                CurrentProMille = currentProMille
            });

        await _context.SaveChangesAsync();

        return booze.Entity;
    }
}
