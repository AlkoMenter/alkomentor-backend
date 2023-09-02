using Alkomentor.Domain;
using Alkomentor.Domain.Booze;
using Alkomentor.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Alkomentor.Infrastructure;

public class PostgresDbContext: DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public DbSet<Profile> Profiles { get; set; }

    public DbSet<Booze> Boozes { get; set; }

    public DbSet<Gulp> Gulps { get; set; }

    public DbSet<Drink> Drinks { get; set; }

    public DbSet<Stage> Stages { get; set; }

    private readonly PostgresDbOptions _postgresDbOptions;

    public PostgresDbContext(IOptions<PostgresDbOptions> postgresDbOptions): base()
    {
        _postgresDbOptions = postgresDbOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_postgresDbOptions.ConnectionString);
}
