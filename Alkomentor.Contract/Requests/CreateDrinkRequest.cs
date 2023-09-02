using System.ComponentModel.DataAnnotations;

namespace Alkomentor.Contract.Requests;

public class CreateDrinkRequest
{
    [Required]
    public required string Name { get; set; }
    
    [Required]
    public double AlcoholPerGram { get; set; }

    public double? Degree { get; set; }
}
