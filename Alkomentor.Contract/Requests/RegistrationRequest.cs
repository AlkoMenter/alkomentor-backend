using System.ComponentModel.DataAnnotations;

namespace Alkomentor.Contract.Requests;

public class RegistrationRequest
{
    [Required]
    public required string Login { get; set; }
    
    [Required]
    public required string Password { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    [Range(18, 150)]
    public int? Age { get; set; }
    
    [Range(1, 300)]
    public double? Weight { get; set; }
    
    [Required]
    public bool? Gender { get; set; }
}