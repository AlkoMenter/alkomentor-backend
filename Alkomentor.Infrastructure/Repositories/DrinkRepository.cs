using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Alkomentor.Infrastructure.Repositories;

internal class DrinkRepository : IDrinkRepository
{
    private readonly PostgresDbContext _context;

    public DrinkRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public async Task<Drink> CreateDrink(string name, double alcoholPerGram, double? degree)
    {
        var drink = _context.Drinks.Add(new Drink 
            {
                Name = name,
                AlcoholPerGram = alcoholPerGram,
                Degree = degree
            });

        await _context.SaveChangesAsync();

        return drink.Entity;
    }

    public async Task<List<Drink>> GetDrinks()
    {
        return await _context.Drinks.ToListAsync();
    }
}
