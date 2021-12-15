// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSI_Food_waste.Models;
using Xunit;

namespace FoodWasteTests
{
    public class UserModelTests
    {
        [Theory]
        [ClassData(typeof(UserData))]
        public void User_Equals_ShouldWork(User user1, User user2, bool expected)
        {
            //Arrange
            //Act
            bool actual = user1.Equals(user2);
            //Assert
            Assert.Equal(expected, actual);
        }

    }

    public class UserData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new User {Email = "email", Password = "pass", Username = "uss"},
                null,
                false
            };
            yield return new object[]
            {
                new User {Email = "email", Password = "pass", Username = "uss"},
                new User {Email = "email", Password = "pass", Username = "uss"},
                true
            };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
