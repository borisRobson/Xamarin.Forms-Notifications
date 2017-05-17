
using Android.App;
using Android.Content;
using Xamarin.Forms;
using LocalNotifications.Droid;
using Android.Media;

[assembly: Dependency(typeof(Notifier_Android))]

namespace LocalNotifications.Droid
{
    class Notifier_Android : Java.Lang.Object,  INotifier
    {
        
        #region Basic_Notification
        /*
        public void Notify(string Title, string Content)
        {
            Context ctx = Android.App.Application.Context.ApplicationContext;
            //Instatntiate the builder and set the notification elements
            Notification.Builder builder = new Notification.Builder(ctx)
                .SetContentTitle(Title)
                .SetContentText(Content)
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                .SetDefaults(NotificationDefaults.All);

            //Build Notification
            Notification notification = builder.Build();

            //Get the notification Manager
            NotificationManager notificationManager =
                ctx.GetSystemService(Context.NotificationService) as NotificationManager;

            //Publish the notification
            const int notificationID = 0;
            notificationManager.Notify(notificationID, notification);                
        }
        */
        #endregion
        
        #region GoTo_Notification

        public void Notify(string Title, string Content)
        {
            Context ctx = Android.App.Application.Context.ApplicationContext;
            //Set up an intent so that tapping the notification returns to this app
            Intent intent = new Intent(ctx, typeof(MainActivity));

            //Create a PendingIntent;
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                PendingIntent.GetActivity(ctx, pendingIntentId, intent, PendingIntentFlags.OneShot);

            //Instantiate the builder and set notification elements, including Pending Intent
            Notification.Builder builder = new Notification.Builder(ctx)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(Title)
                .SetContentText(Content)
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click);

            //Build the notification
            Notification notification = builder.Build();

            //Get the notification manager
            NotificationManager notificationManager =
                ctx.GetSystemService(Context.NotificationService) as NotificationManager;

            //Publish the notification
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
        #endregion

    }
}