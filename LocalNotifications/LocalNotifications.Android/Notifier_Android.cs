using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using Java.Lang;
using LocalNotifications.Droid;

[assembly: Dependency(typeof(Notifier_Android))]

namespace LocalNotifications.Droid
{
    class Notifier_Android : Java.Lang.Object,  INotifier
    {

        public void Notify(string Title, string Content)
        {
            Context ctx = Android.App.Application.Context.ApplicationContext;
            //Instatntiate the builder and set the notification elements
            Notification.Builder builder = new Notification.Builder(ctx)
                .SetContentTitle(Title)
                .SetContentText(Content)
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click);

            //Build Notification
            Notification notification = builder.Build();

            //Get the notification Manager
            NotificationManager notificationManager =
                ctx.GetSystemService(Context.NotificationService) as NotificationManager;

            //Publish the notification
            const int notificationID = 0;
            notificationManager.Notify(notificationID, notification);

                
        }
    }
}