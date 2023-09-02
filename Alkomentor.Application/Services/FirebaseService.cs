using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Alkomentor.Application;

public class FirebaseService : IFirebaseService
{
    private readonly FirebaseMessaging messaging;
    
    public FirebaseService()
    {
        var app = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("secret-key.json")
                .CreateScoped("https://www.googleapis.com/auth/firebase.messaging")
        });
        messaging = FirebaseMessaging.GetMessaging(app);
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