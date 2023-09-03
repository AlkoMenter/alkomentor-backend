using System.ComponentModel.DataAnnotations;

namespace Alkomentor.Contract.Requests;

public class CreateBoozeRequest
{
    [Required]
    public Guid ProfileId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? StopTime { get; set; }

    public Guid? StageId { get; set; }

    public double CurrentProMille { get; set; }

    public Guid[]? SelectedDrinkIds { get; set; }
}
