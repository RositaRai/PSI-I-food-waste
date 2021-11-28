// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using PSI_Food_waste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSI_Food_waste.Services;
using PSI_Food_waste.Data;

namespace PSI_Food_waste.Services
{
    public class RestaurantServices : IRestaurantRepository
    {
        List<Restaurant> Restaurants { get; }

        public int nextID = 2;

        private readonly ProductContext _context;

        public RestaurantServices(ProductContext context)
        {
            _context = context;
            Restaurants = _context.Restaurants.ToList();
            //Restaurants = new List<Restaurant>()
            //{
            //    new Restaurant { Title = "Chilli pica", City = "Kaunas",Adress = "Kauno g. 15", Id = 1},
            //    new Restaurant {Title = "Charlie pica", City = "Vilnius", Adress = "Vilniaus g. ", Id = 2}
            //};
        }
        public List<Restaurant> GetAll() => Restaurants;
        public Restaurant Get(int id) => Restaurants.FirstOrDefault(p => p.Id  == id);

        public async Task Add(Restaurant restaurant)
        {

            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
            ++nextID;
            //Restaurant.Id = ++nextID;
            //Restaurants.Add(Restaurant);

        }
        public void Update(Restaurant Restaurant)
        {
            var index = Restaurants.FindIndex(p => p.Id == Restaurant.Id);
            if (index == -1)
                return;

            Restaurants[index] = Restaurant;
        }
        public int GetID()
        {
            return nextID;
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
