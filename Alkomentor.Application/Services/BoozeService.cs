using Alkomentor.Application.Models;
using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Utils;
using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using Hangfire;

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

    public async Task<BoozeSchedule?> CalculateBoozeSchedule(Guid boozeId)
    {
        var booze = await _boozeRepository.GetBooze(boozeId);

        if (booze is null
            || booze.StopTime is null
            || booze.StopTime <= booze.StartTime
            || booze.SelectedDrinks is null
            || !booze.SelectedDrinks.Any()
            || booze.Profile.Weight is null
            || booze.Stage is null)
            return null;

        var boozeSchedule = new BoozeSchedule
        {
            Booze = Mapper.Map<Booze, BoozeDto>(booze),
            ScheduledDrinks = new List<ScheduledDrink>()
        };
        
        var timeOfBooze = (booze.StopTime - booze.StartTime).Value;
        var neededProMille = Math.Round((booze.Stage!.MinProMille + booze.Stage.MaxProMille) / 2, 3);
        var devidedProMille = Math.Round(neededProMille - booze.CurrentProMille, 3);
        var pogreshnost = timeOfBooze.Hours * 0.15;
        devidedProMille += pogreshnost;
        var vidmarkCoeff = booze.Profile.Gender.HasValue && booze.Profile.Gender.Value ? 0.6 : 0.7;

        foreach (var selectedDrink in booze.SelectedDrinks)
        {
            var scheduledDrink = new ScheduledDrink
            {
                Drink = Mapper.Map<Drink, DrinkDto>(selectedDrink),
                ScheduledGulps = new List<ScheduledGulp>()
            };
            
            var etanolSize = booze.Profile.Weight!.Value * devidedProMille * vidmarkCoeff;
            var drinkPortion = etanolSize / selectedDrink.AlcoholPerGram;

            scheduledDrink.NeededCapacity = drinkPortion;
            var gulpCount = drinkPortion / selectedDrink.Dosage;
            var interval = timeOfBooze.TotalMinutes / gulpCount;

            for (var i = 0; i < gulpCount; i++)
            {
                scheduledDrink.ScheduledGulps.Add(new ScheduledGulp
                {
                    GulpTime = booze.StartTime.AddMinutes(i * interval),
                    Size = selectedDrink.Dosage
                });
            }
            boozeSchedule.ScheduledDrinks.Add(scheduledDrink);
        }

        return boozeSchedule;
    }
}