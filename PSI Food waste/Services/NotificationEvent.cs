// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using AspNetCoreHero.ToastNotification.Abstractions;

namespace PSI_Food_waste.Services
{
    public class NotificationEvent : INotificationEvent
    {
        public delegate void ShowNotification(object sender, string name, int notifType);

        public event ShowNotification NotificationEvent1;
        public void RaiseEvent(object sender, string e,INotyfService notyf, int notifType)
        {
            var Notifier = new NotificationEvent();
            ShowNotification showNotification;
            NotificationEvent1 +=  showNotification = delegate (object sender, string name, int type)
            {
                if (type == 0)
                {
                    string s = string.Format("{0} successfuly added", name);
                    notyf.Success(s);
                }
                if (type == 1)
                {
                    string s = string.Format("{0} successfuly removed", name);
                    notyf.Warning(s);
                }
            };
            NotificationEvent1?.Invoke(sender, e, notifType);
        }
    }
}
