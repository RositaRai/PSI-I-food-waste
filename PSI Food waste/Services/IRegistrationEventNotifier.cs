// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;

namespace PSI_Food_waste.Services
{
    public interface IRegistrationEventNotifier
    {
        void OnSucessfullRegistrationEvent(object sender, string e);
        void RaiseEvent(Object sender, string e);
        //event EventHandler<string> SuccessfulRegistrationEvent;
    }
}
