namespace Alkomentor.Contract.Dto;

public class EditProfileDto
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public int Age { get; set; }
    
    public int Weight { get; set; }
    
    public bool Gender { get; set; }
    
    public string? NotifyToken { get; set; }
}