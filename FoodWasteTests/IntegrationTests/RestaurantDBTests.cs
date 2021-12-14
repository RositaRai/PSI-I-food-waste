// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSI_Food_waste.Data;
using PSI_Food_waste.Models;
using Xunit;

namespace FoodWasteTests.IntegrationTests
{
    public class RestaurantDBTests
    {
        private Restaurant testRestaurant = new Restaurant { Id = Guid.NewGuid(), Adress = "Zirmunu g. 15", City = "Vilinius", PictureUrl = null, Title = "Charlie pica"};

        private Restaurant testRestaurant2 = new Restaurant { Id = Guid.NewGuid(), Adress = "Zirmunu g. 10", City = "Kaunas", PictureUrl = null, Title = "Chilli pica" };

        [Fact]
        public void Restaurants_getRestaurantsListfromDataBase()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            DbContextOptionsBuilder<ProductContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            using (var ctx = new ProductContext(optionsBuilder.Options))
            {
                TestRestaurantsList(ctx, null, false);
                ctx.Restaurants.Add(testRestaurant);
                ctx.Restaurants.Add(testRestaurant2);
                ctx.SaveChanges();
                TestRestaurantsList(ctx, testRestaurant, true);
                TestRestaurantsList(ctx, testRestaurant2, true);
                ctx.Restaurants.Remove(testRestaurant);
                ctx.SaveChanges();
                TestRestaurantsList(ctx, testRestaurant, false);
            }
        }
        [Fact]
        public void Restaurants_getRestaurantfromDataBase()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            DbContextOptionsBuilder<ProductContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            using (var ctx = new ProductContext(optionsBuilder.Options))
            {
                TestRestaurantsList(ctx, null, false);
                ctx.Restaurants.Add(testRestaurant);
                ctx.Restaurants.Add(testRestaurant2);
                ctx.SaveChanges();
                TestRestaurant(ctx, testRestaurant, testRestaurant.Id);
                TestRestaurant(ctx, testRestaurant2, testRestaurant2.Id);
                ctx.Restaurants.Remove(testRestaurant);
                ctx.SaveChanges();
                TestRestaurant(ctx, testRestaurant2, testRestaurant2.Id);
            }
        }
        private void TestRestaurantsList(ProductContext ctx, Restaurant testRestaurant, bool expected)
        {
            var data = ctx.Restaurants.ToList();
            Assert.NotNull(data);
            Assert.Equal(expected, data.Contains(testRestaurant));
        }
        private void TestRestaurant(ProductContext ctx, Restaurant testRestaurant, Guid id)
        {
            var data = ctx.Restaurants.FirstOrDefault(pr => pr.Id == id);
            Assert.NotNull(data);
            Assert.Equal(testRestaurant, data);
        }
    }
}
