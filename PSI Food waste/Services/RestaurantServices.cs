// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using PSI_Food_waste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSI_Food_waste.Services;

namespace PSI_Food_waste.Services
{

    public class RestaurantServices : IRestaurantRepository
    {
        public Guid CurrentId { get; set; }
        List<Restaurant> Restaurants { get; }

        public RestaurantServices()
        {
            CurrentId = Guid.Empty;
            Restaurants = new List<Restaurant>()
            {
                new Restaurant { Title = "Chilli pica", City = "Kaunas",Adress = "Kauno g. 15", Id = Guid.NewGuid(), WorkerID = 1 },
                new Restaurant {Title = "Charlie pica", City = "Vilnius", Adress = "Vilniaus g. ", Id = Guid.NewGuid(), WorkerID = 2 }
            };
        }
        public List<Restaurant> GetAll() => Restaurants;
        public Restaurant Get(Guid id) => Restaurants.FirstOrDefault(p => p.Id  == id);

        public void Add(Restaurant Restaurant)
        {
 
            Restaurant.Id = Guid.NewGuid();
            Restaurants.Add(Restaurant);

        }
        public void Update(Restaurant Restaurant)
        {
            var index = Restaurants.FindIndex(p => p.Id == Restaurant.Id);
            if (index == -1)
                return;

            Restaurants[index] = Restaurant;
        }
        public Guid GetID(Restaurant restaurant)
        {
            var rest = Restaurants.FirstOrDefault(p => p.Id == restaurant.Id);
            return rest.Id;
        }
    }
    public static class RestaurantServicesExtension
    {
        public static List<T> Where<T>(this List<T> items, Func<T, string, bool> condition, string conditionString)
        {
            var list = new List<T>();
            foreach (var item in items)
            {
                if (condition(item, conditionString))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
