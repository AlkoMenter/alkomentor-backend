using Alkomentor.Domain.Booze;

namespace Alkomentor.Infrastructure.RepositoryInterfaces;

public interface IDrinkRepository
{
    Task<Drink> CreateDrink(string name, double alcoholPerGram, double? degree);
}
