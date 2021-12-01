// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PSI_Food_waste.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Restaurant otherRestaurant = obj as Restaurant;
            if (otherRestaurant != null)
                return this.Id.CompareTo(otherRestaurant.Id);
            else
                throw new ArgumentException("Object is not a Restaurant");
        }

        protected bool Equals(Restaurant other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var other = obj as Restaurant;
            return other != null && Equals(other);
        }
    }
}
