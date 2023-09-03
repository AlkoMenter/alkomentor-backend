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
                StartTime = startTime.ToUniversalTime(),
                StopTime = stopTime?.ToUniversalTime(),
                Stage = stage,
                CurrentProMille = currentProMille
            });

        await _context.SaveChangesAsync();

        return booze.Entity;
    }

    public async Task<Booze?> GetBooze(Guid boozeId)
    {
        var booze = await _context.Boozes
            .AsNoTracking()
            .Include(x => x.Gulps)
            .Include(x => x.SelectedDrinks)
            .Include(x => x.Stage)
            .Include(x => x.Profile)
            .FirstOrDefaultAsync(x => x.Id == boozeId);
        
        if (booze?.CurrentProMilleUpdated is not null)
        {
            var hours = (DateTime.Now.ToUniversalTime() - booze!.CurrentProMilleUpdated).Value.TotalHours;

            booze.CurrentProMille = hours * 0.15 > booze.CurrentProMille ? 0 : booze.CurrentProMille - hours * 0.15;
        }

        return booze;
    }

    public async Task SetCurrentProMille(Guid boozeId, double proMille)
    {
        var booze = await _context.Boozes.FirstOrDefaultAsync(x => x.Id == boozeId);
        
        if (booze is null) return;
        
        booze.CurrentProMille = proMille;
        booze.CurrentProMilleUpdated = DateTime.Now.ToUniversalTime();
        await _context.SaveChangesAsync();
    }

    public async Task<Gulp?> CreateGulp(Guid boozeId, double Size, Guid drinkId, DateTime gulpTime)
    {
        var booze = await _context.Boozes.FirstOrDefaultAsync(x => x.Id == boozeId);

        var drink = await _context.Drinks.FirstOrDefaultAsync(x => x.Id == drinkId);

        if (booze is null || drink is null) return null;

        var gulp = _context.Gulps.Add(new Gulp
        {
            Booze = booze,
            Drink = drink,
            Size = Size,
            GulpTime = gulpTime.ToUniversalTime()
        });

        await _context.SaveChangesAsync();

        return gulp.Entity;
    }
}
