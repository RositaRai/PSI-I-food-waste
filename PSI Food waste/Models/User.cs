// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PSI_Food_waste.Models
{
    public class User : IEquatable<User>
    {
        public String Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PictureUrl { get; set; }
        

        public bool Equals (User other)
        {
            if (other == null)
                return false;
            if (this.Email == other.Email && this.Password == other.Password)
                return true;
            else
                return false;
        }
    }
}
