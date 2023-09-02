using System.ComponentModel.DataAnnotations;

namespace Alkomentor.Contract.Requests;

public class CreateStageRequest
{
    [Required]
    public required string Name { get; set; }

    public double MinProMille { get; set; }

    public double MaxProMille { get; set; }
}
