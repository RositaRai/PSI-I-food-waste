// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSI_Food_waste.Services;

namespace PSI_Food_waste.Models
{
    public interface IRestaurantRepository
    {
        Guid CurrentId {  get; set; }
        public void Add(Restaurant Restaurant);
        public List<Restaurant> GetAll();
        public Restaurant Get(Guid id);
        public Guid GetID(Restaurant restaurant);
    }
}
