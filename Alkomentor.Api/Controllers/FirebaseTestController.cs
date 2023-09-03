using Alkomentor.Application.ServiceInterfaces;
using Hangfire;
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
    
    [HttpGet("send2")]
    public async Task<ActionResult> SendHang()
    {
        var res = BackgroundJob.Schedule(() => Console.WriteLine("test"), new TimeSpan(0, 0, 0, 30));
        
        return Ok(res);
    }
    [HttpGet("send3")]
    public async Task<ActionResult> SendHang(string token)
    {
        return Ok(BackgroundJob.Delete(token));
    }
    
}