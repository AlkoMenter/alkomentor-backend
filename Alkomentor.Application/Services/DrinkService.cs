using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.RepositoryInterfaces;

namespace Alkomentor.Application.Services;

internal class DrinkService : IDrinkService
{
    private readonly IDrinkRepository _drinkRepository;

    public DrinkService(IDrinkRepository drinkRepository)
    {
        _drinkRepository = drinkRepository;
    }

    public async Task<Drink> CreateDrink(string name, double alcoholPerGram, double? degree, double dosage)
        => await _drinkRepository.CreateDrink(name, alcoholPerGram, degree, dosage);

    public async Task<List<Drink>> GetDrinks() 
        => await _drinkRepository.GetDrinks();
}
