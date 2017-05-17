using System;
using Xamarin.Forms;

namespace LocalNotifications
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var notifictaion = new Button {
                Text = "Notify!",
                VerticalOptions= LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            notifictaion.Clicked += (sender, e) =>
            {
                DependencyService.Get<INotifier>().Notify("Forms Notification", "From Forms");
            };
            Content = notifictaion;

        }
    }
}
