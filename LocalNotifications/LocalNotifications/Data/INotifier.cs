using System;

namespace LocalNotifications
{
    public interface INotifier
    {
        void Notify(string Title, string Content);
    }
}
