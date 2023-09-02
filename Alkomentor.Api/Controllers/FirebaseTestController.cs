using Alkomentor.Application;
using Microsoft.AspNetCore.Mvc;

namespace Alkomentor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FirebaseTestController : ControllerBase
{
    private readonly IFirebaseService _firebaseService;

    public FirebaseTestController(IFirebaseService firebaseService)
    {
        _firebaseService = firebaseService;
    }

    [HttpGet("send")]
    public async Task<ActionResult> SendFirebase(string token, string title, string body)
    {
        await _firebaseService.SendNotification(token, title, body);
        
        return Ok();
    }
    
}