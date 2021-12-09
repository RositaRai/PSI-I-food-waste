// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI_Food_waste.Models
{
    public interface IRestaurantRepository
    {
        public Task AddAsync(Restaurant restaurant);
        public List<Restaurant> GetAll();
        public Restaurant Get(Guid id);
        public Guid GetID(Restaurant restaurant);
        //public int GetID();
    }
}
