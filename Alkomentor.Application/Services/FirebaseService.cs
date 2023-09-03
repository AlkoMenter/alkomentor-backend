using Alkomentor.Application.ServiceInterfaces;
using Alkomentor.Infrastructure.RepositoryInterfaces;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Hangfire;
using Microsoft.Extensions.Caching.Memory;

namespace Alkomentor.Application.Services;

public class FirebaseService : IFirebaseService
{
    private readonly FirebaseMessaging messaging;
    private readonly IProfileService _profileService;
    private IMemoryCache _scheduleDrinksCache;
    public FirebaseService(IProfileService profileService, IMemoryCache scheduleDrinksCache)
    {
        _profileService = profileService;
        _scheduleDrinksCache = scheduleDrinksCache;
        var app = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("secret-key.json")
                .CreateScoped("https://www.googleapis.com/auth/firebase.messaging")
        });
        messaging = FirebaseMessaging.GetMessaging(app);
    }
    
    public async Task ScheduleDrinkNotification(Guid profileId, List<DateTime> drinkDates)
    {
        List<string> scheduleIds = new List<string>();
        foreach (var drinkDate in drinkDates)
        {
            scheduleIds.Add(BackgroundJob.Schedule(
                () => SendNotificationAboutDrink(profileId), drinkDate - DateTime.UtcNow));
        }
        
        _scheduleDrinksCache.Set(profileId, scheduleIds);
    }

    public void RemoveDrinkNotification(Guid profileId)
    {
        if (_scheduleDrinksCache.TryGetValue(profileId, out List<string>? scheduleIds))
        {
            foreach (var scheduleId in scheduleIds!)
            {
                BackgroundJob.Delete(scheduleId);
            }
            _scheduleDrinksCache.Remove(profileId);
        }
    }

    public async Task SendNotificationAboutDrink(Guid profileId)
    {
        var profile = await _profileService.GetProfile(profileId);

        var title = "Время выпить!";
        var body = "Настало время выпить для поддержания нужной кондиции!";

        await SendNotification(profile.NotifyToken, title, body);
    }

    public async Task SendNotification(string token, string title, string body)
    {
        var message = CreateNotification(token, title, body);

        await messaging.SendAsync(message);
    }
    
    private Message CreateNotification(string token, string title, string notificationBody)
    {    
        return new Message
        {
            Token = token,
            Notification = new Notification()
            {
                Body = notificationBody,
                Title = title
            }
        };
    }
}