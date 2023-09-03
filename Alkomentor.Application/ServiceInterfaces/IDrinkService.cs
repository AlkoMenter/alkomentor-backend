using Alkomentor.Domain.Booze;

namespace Alkomentor.Application.ServiceInterfaces;

public interface IDrinkService
{
    Task<Drink> CreateDrink(string name, double alcoholPerGram, double? degree);

    Task<List<Drink>> GetDrinks();
}
