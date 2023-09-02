namespace Alkomentor.Domain;

public class BoozeDrink
{
    public Guid Id { get; set; }

    public Drink? Drink { get; set; }

    public Booze? Booze { get; set; }

    public double Size { get; set; }

    public DateTime PlanTime { get; set; }

    public DateTime? FactTime { get; set; }
}
