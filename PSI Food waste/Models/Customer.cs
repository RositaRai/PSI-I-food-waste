// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace PSI_Food_waste.Models
{
    
    public class Customer : User
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public Customer()
        {

        }

        public Customer(string username, string password, string email, string picture,
                        string name, string surname)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Username = username;
            Password = password;
            PictureUrl = string.IsNullOrWhiteSpace(picture) ? "https://www.topdeal.lt/wp-content/themes/consultix/images/no-image-found-360x250.png" : picture;
        }


    }
}
