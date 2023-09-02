using System.ComponentModel.DataAnnotations;

namespace Alkomentor.Contract.Requests;

public class EditProfileRequest
{
    [Required]
    public Guid AccountId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Range(18, 150)]
    public int Age { get; set; }
    
    [Range(1, 300)]
    public int Weight { get; set; }
    
    [Required]
    public bool Gender { get; set; }
}