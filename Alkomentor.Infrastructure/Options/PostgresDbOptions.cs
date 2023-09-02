namespace Alkomentor.Infrastructure.Options;

public class PostgresDbOptions
{
    public const string SectionName = "PostgresDbOptions";

    public string? ConnectionString { get; set; }
}
