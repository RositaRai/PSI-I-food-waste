// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using PSI_Food_waste.Models;

namespace PSI_Food_waste.Services
{
    public interface IRegistrationEventNotifier
    {
        void OnSucessfullRegistrationEvent(object sender, EmailNotificationArgs e);
        void RaiseEvent(object sender, EmailNotificationArgs e);
        //event EventHandler<string> SuccessfulRegistrationEvent;
    }
}
