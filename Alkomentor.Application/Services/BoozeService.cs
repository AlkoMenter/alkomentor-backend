using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Contract.Dto;
using Alkomentor.Contract.Utils;
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

    public async Task<BoozeDto?> GetBooze(Guid boozeId)
    {
        var booze = await _boozeRepository.GetBooze(boozeId);

        if (booze is null) return null;
        
        var boozeDto = Mapper.Map<Booze, BoozeDto>(booze);

        if (boozeDto is null) return null;
        
        boozeDto.Schedule = CalculateSchedule(booze);

        return boozeDto;
    }

    public async Task<BoozeDto?> Drink(Guid boozeId, Guid drinkId)
    {
        var booze = await _boozeRepository.GetBooze(boozeId);

        if (booze is null) return null;
        
        var schedule = CalculateSchedule(booze);

        var gulpedDrink = schedule?.ScheduledDrinks?
            .FirstOrDefault(x => x.Drink != null && x.Drink.Id == drinkId);

        var factGulp = gulpedDrink?.ScheduledGulps?.MinBy(x => x.GulpTime);

        if (factGulp is null) return null;

        var gulp = await _boozeRepository
            .CreateGulp(boozeId, factGulp.Size, gulpedDrink!.Drink!.Id, DateTime.Now);
        
        if (gulp is null) return null;

        var currentProMille = booze.CurrentProMille + CalculateProMille(
            booze.Profile.Weight!.Value,
            booze.Profile.Gender!.Value,
            gulpedDrink.Drink.AlcoholPerGram,
            factGulp.Size);

        await _boozeRepository.SetCurrentProMille(boozeId, currentProMille);

        booze.CurrentProMille = currentProMille;

        booze.Gulps ??= new List<Gulp>();
        
        booze.Gulps.Add(gulp);
        
        var boozeDto = Mapper.Map<Booze, BoozeDto>(booze);

        if (boozeDto is null) return null;
        
        boozeDto.Schedule = CalculateSchedule(booze);
        
        return boozeDto;
    }

    private double CalculateProMille(double weight, bool gender, double etanolPerGramm, double drinkSize)
        => drinkSize * etanolPerGramm / (weight * (gender ? 0.6 : 0.7));

    private BoozeScheduleDto? CalculateSchedule(Booze? booze)
    {
        if (booze?.StopTime is null
            || booze.StopTime <= booze.StartTime
            || booze.SelectedDrinks is null
            || !booze.SelectedDrinks.Any()
            || booze.Profile.Weight is null
            || booze.Stage is null)
            return null;

        var boozeSchedule = new BoozeScheduleDto { ScheduledDrinks = new List<ScheduleDrinkDto>() };
        
        var startTime = booze.Gulps is not null && booze.Gulps.Any()
            ? booze.Gulps.MaxBy(x => x.GulpTime)?.GulpTime ?? booze.StartTime
            : booze.StartTime; 

        var timeOfBooze = booze.StopTime!.Value - startTime;
        var neededProMille = Math.Round((booze.Stage!.MinProMille + booze.Stage.MaxProMille) / 2, 3);

        if (neededProMille < booze.CurrentProMille) return null;
        
        var devidedProMille = Math.Round(neededProMille - booze.CurrentProMille, 3);
        var pogreshnost = timeOfBooze.Hours * 0.15;
        devidedProMille += pogreshnost;
        var vidmarkCoeff = booze.Profile.Gender.HasValue && booze.Profile.Gender.Value ? 0.6 : 0.7;

        foreach (var selectedDrink in booze.SelectedDrinks)
        {
            var scheduledDrink = new ScheduleDrinkDto
            {
                Drink = Mapper.Map<Drink, DrinkDto>(selectedDrink),
                ScheduledGulps = new List<ScheduleGulpDto>()
            };
            
            var etanolSize = booze.Profile.Weight!.Value * devidedProMille * vidmarkCoeff;
            var drinkPortion = etanolSize / selectedDrink.AlcoholPerGram;

            scheduledDrink.NeededCapacity = drinkPortion;
            var gulpCount = drinkPortion / selectedDrink.Dosage;
            var interval = timeOfBooze.TotalMinutes / gulpCount;

            for (var i = 0; i < gulpCount; i++)
            {
                scheduledDrink.ScheduledGulps.Add(new ScheduleGulpDto
                {
                    GulpTime = startTime.AddMinutes(i * interval),
                    Size = selectedDrink.Dosage
                });
            }

            if (booze.Gulps is null || !booze.Gulps.Any())
                scheduledDrink.CurrentBottleStep = 0;
            else
            {
                var allGulps = booze.Gulps.Count + scheduledDrink.ScheduledGulps.Count;
                var allBottleSteps = 10;
                var onegulpPercentage = 100 / allGulps;
                var oneBottleStepPercentage = 100 / allBottleSteps;
                var currentGulpPercentage = booze.Gulps.Count * onegulpPercentage;
                scheduledDrink.CurrentBottleStep = currentGulpPercentage / oneBottleStepPercentage;
            }
            
            boozeSchedule.ScheduledDrinks.Add(scheduledDrink);
        }

        return boozeSchedule;
    }
}