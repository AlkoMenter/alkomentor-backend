namespace Alkomentor.Application.ServiceInterfaces;

public interface IFirebaseService
{
    Task SendNotification(string token, string title, string body);
}