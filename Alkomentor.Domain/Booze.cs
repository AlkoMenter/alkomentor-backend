namespace Alkomentor.Domain;

public class Booze
{
    public Guid Id { get; set; }

    public required DateTime StartTime { get; set; }

    public DateTime? StopTime { get; set; }

    public Profile? Profile { get; set; }

    public Stage? Stage { get; set; }
}
