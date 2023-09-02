namespace Alkomentor.Application;

public interface IFirebaseService
{
    Task SendNotification(string token, string title, string body);
}