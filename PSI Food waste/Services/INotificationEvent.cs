// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using AspNetCoreHero.ToastNotification.Abstractions;

namespace PSI_Food_waste.Services
{
    public interface INotificationEvent
    {
        void RaiseEvent(object sender, string e, INotyfService notyf, int notifType);
    }
}
