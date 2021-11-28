// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSI_Food_waste.Models;

namespace PSI_Food_waste.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            if(context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product{RestId = 1, Name = "Product_1", Size=ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 10, Discount = 0},
                new Product{RestId = 1, Name = "Product_2", Size=ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 10, Discount = 0},
                new Product{RestId = 1, Name = "Product_3", Size=ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 10, Discount = 0},
                new Product{RestId = 2, Name = "Product_4", Size=ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 10, Discount = 0},
                new Product{RestId = 2, Name = "Product_5", Size=ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 10, Discount = 0},
                new Product{RestId = 2, Name = "Product_6", Size=ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 10, Discount = 0}
            };

            context.Products.AddRangeAsync(products);
            context.SaveChangesAsync();

            var restaurants = new Restaurant[]
            {
                new Restaurant {Title = "Restaurant_1", City = "Kaunas", Adress = "Kauno g. 15"},
                new Restaurant {Title = "Restaurant_2", City = "Vilnius", Adress = "Vilniaus g. "}
            };

            context.Restaurants.AddRangeAsync(restaurants);
            context.SaveChangesAsync();
        }
    }
}
