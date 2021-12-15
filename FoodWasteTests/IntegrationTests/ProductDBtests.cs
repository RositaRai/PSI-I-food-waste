// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using PSI_Food_waste.Data;
using System.Reflection;
using PSI_Food_waste.Models;

namespace FoodWasteTests.IntegrationTests
{
    public class ProductDBtests
    {
        private Product testProduct = new Product { PrID = Guid.NewGuid(), RestId = Guid.NewGuid(), Name = "Pica", Discount = 50, Price = 10, DiscountedPrice = 5, IsGlutenFree = false, Size = ProductSize.Small};

        private Product testProduct2 = new Product { PrID = Guid.NewGuid(), RestId = Guid.NewGuid(), Name = "Burgeris", Discount = 50, Price = 10, DiscountedPrice = 5, IsGlutenFree = false, Size = ProductSize.Small };

        [Fact]
        public void Products_getProductsFromDataBase()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            DbContextOptionsBuilder<ProductContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            using (var ctx = new ProductContext(optionsBuilder.Options))
            {
                TestProductsList(ctx, null, false);
                ctx.Products.Add(testProduct);
                ctx.SaveChanges();
                TestProductsList(ctx, testProduct, true);
                ctx.Products.Remove(testProduct);
                ctx.SaveChanges();
                TestProductsList(ctx, testProduct, false);
            }
        }

        [Fact]
        public void Products_getProductFromDataBase()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            DbContextOptionsBuilder<ProductContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            using (var ctx = new ProductContext(optionsBuilder.Options))
            {
               ctx.Products.Add(testProduct);
               ctx.Products.Add(testProduct2);
               ctx.SaveChanges();
               TestProduct(ctx, testProduct, testProduct.PrID);
               TestProduct(ctx, testProduct2, testProduct2.PrID);

            }
        }
        private void TestProductsList(ProductContext ctx, Product testProduct, bool expected)
        {
            var data = ctx.Products.ToList();
            Assert.NotNull(data);
            Assert.Equal(expected, data.Contains(testProduct));
        }
        private void TestProduct(ProductContext ctx,Product testProduct, Guid id)
        {
            var data = ctx.Products.FirstOrDefault(pr => pr.PrID == id);
            Assert.NotNull(data);
            Assert.Equal(testProduct, data);
        }
    }
}
