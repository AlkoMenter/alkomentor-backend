using System.ComponentModel.DataAnnotations;

namespace Alkomentor.Contract.Requests;

public class UpdateNotifyTokenRequest
{
    [Required]
    public Guid ProfileId { get; set; }
    
    [Required]
    public string NotifyToken { get; set; }
}