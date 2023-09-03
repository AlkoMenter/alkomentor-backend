namespace Alkomentor.Application.ServiceInterfaces;

public interface IFirebaseService
{
    Task ScheduleDrinkNotification(Guid profileId, List<DateTime> drinkDates);

    void RemoveDrinkNotification(Guid profileId);
    Task SendNotificationAboutDrink(Guid profileId);
    Task SendNotification(string token, string title, string body);
}