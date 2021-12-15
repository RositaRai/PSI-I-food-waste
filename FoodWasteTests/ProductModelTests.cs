// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSI_Food_waste.Models;
using Xunit;

namespace FoodWasteTests
{
    public class ProductModelTests
    {
        [Fact]
        public void Product_CompareTo_ThrowsException()
        {
            //Arrange
            var product1 = new Product { PrID = Guid.NewGuid(), RestId = Guid.NewGuid(), Name = "product", Size = ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 5, Discount = 50 };
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => product1.CompareTo(new object()));
        }

        [Fact]
        public void Product_CompareTo_ShoulReturnTrue()
        {
            //Arrange
            var product = new Product { PrID = Guid.NewGuid(), RestId = Guid.NewGuid(), Name = "product", Size = ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 5, Discount = 50 };
            int expected = 0;
            //Act
            int actual = product.CompareTo(product);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product_CompareTo_ShoulReturnFalse()
        {
            //Arrange
            var product1 = new Product { PrID = Guid.NewGuid(), RestId = Guid.NewGuid(), Name = "product1", Size = ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 5, Discount = 50 };
            var product2 = new Product { PrID = Guid.NewGuid(), RestId = Guid.NewGuid(), Name = "product2", Size = ProductSize.Small, IsGlutenFree = false, Price = 10, DiscountedPrice = 10, Discount = 50 };
            int expected = -1;
            //Act
            int actual = product1.CompareTo(product2);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
