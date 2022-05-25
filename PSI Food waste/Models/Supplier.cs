// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace PSI_Food_waste.Models
{
    public class Supplier : User
    {
        public int SupplierId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Supplier()
        {

        }

        public Supplier(string title, string city, string address, string username, string password, string email, string image)
        {
            Title = title;
            City = city;
            Address = address;
            Username = username;
            Password = password;
            Email = email;
            PictureUrl = string.IsNullOrWhiteSpace(image) ? "https://www.topdeal.lt/wp-content/themes/consultix/images/no-image-found-360x250.png" : image;
        }
    }
}
