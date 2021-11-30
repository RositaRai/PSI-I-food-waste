// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Food_waste.Models
{
    public interface IRegisterRepository
    {
        public RegisterForm CurrentUser { get; set; }
        public RegisteredUser<RegisterForm> GetAll();

        public RegisterForm GetUserData(string email);

        public Lazy<RegisteredUser<RegisterForm>> GetUsersObject();

        public void AddToList(RegisterForm user);
    }
}
