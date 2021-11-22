// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace PSI_Food_waste.Models
{
    public class EmailNotificationArgs : EventArgs
    {
        public string _email;

        public string _msg;
        public EmailNotificationArgs(string email, string msg)
        {
            _email = email;
            _msg = msg;
        }
    }
}
