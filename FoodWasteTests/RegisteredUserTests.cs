// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSI_Food_waste.Models;
using Xunit;

namespace FoodWasteTests
{
    public class RegisteredUserTests
    {
        [Fact]
        public void RegisteredUser_Add_ShouldWork()
        {
            //Arrange
            RegisteredUser<RegisterForm> registeredUsers = new RegisteredUser<RegisterForm>();
            RegisterForm newUser = new RegisterForm(new List<Restaurant>(), new List<Restaurant>(), "email@name.com", "name", "name", 0);
            registeredUsers.Add(newUser);
            //Act
            bool actual = registeredUsers.Contains(newUser);
            //Assert
            Assert.True(registeredUsers.Length() == 1);
            Assert.True(actual);
        }

        [Fact]
        public void RegisteredUser_Add_ThrowsException()
        {
            RegisteredUser<RegisterForm> registeredUsers = new RegisteredUser<RegisterForm>();

            for(int i = 0; i < 100; ++i)
            {
                RegisterForm newUsertemp = new RegisterForm(new List<Restaurant>(), new List<Restaurant>(), $"email{i}@name.com", "name", "name", 0);
                registeredUsers.Add(newUsertemp);
            }

            RegisterForm newUser = new RegisterForm(new List<Restaurant>(), new List<Restaurant>(), $"email@name.com", "name", "name", 0);

            Assert.Throws<IndexOutOfRangeException>(() =>
                registeredUsers.Add(newUser)
            );
        }
    }
}

