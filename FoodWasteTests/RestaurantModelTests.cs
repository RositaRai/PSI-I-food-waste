using System;
using System.Collections;
using System.Collections.Generic;
using PSI_Food_waste.Models;
using Xunit;

namespace FoodWasteTests
{
    public class RestaurantModelTests
    {
        //[Fact]
        //public void Restaurant_Equals_ShouldReturnTrue()
        //{
        //    //Arrange
        //    Guid Guid1 = new Guid();
        //    Guid Guid2 = new Guid();
        //    Restaurant Restaurant1 = new Restaurant {Id = Guid1, Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };
        //    Restaurant Restaurant2 = new Restaurant {Id = Guid2, Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };
        //    //Act
        //    bool Bool = Restaurant1.Equals(Restaurant2);

        //    //Assert
        //    Assert.True(Bool);
        //}

        //[Fact]
        //public void Restaurant_Equals_OnGetsNullShouldReturnFalse()
        //{
        //    //Arrange
        //    Guid Guid1 = new Guid();
        //    Restaurant Restaurant1 = new Restaurant { Id = Guid1, Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };
        //    //Act
        //    bool Bool = Restaurant1.Equals(null);

        //    //Assert
        //    Assert.False(Bool);
        //}

        //[Fact]
        //public void Restaurant_Equals_OnSameReferenceShouldReturnTrue()
        //{
        //    //Arrange
        //    Guid Guid1 = new Guid();
        //    Restaurant Restaurant1 = new Restaurant { Id = Guid1, Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };
        //    Restaurant Restaurant2 = Restaurant1;
        //    //Act
        //    bool Bool = Restaurant1.Equals(Restaurant2);

        //    //Assert
        //    Assert.True(Bool);
        //}

        [Fact]
        public void Restaurant_CompareTo_ThrowsException()
        {
            //Arrange
            var rest1 = new Restaurant { Id = Guid.NewGuid(), Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => rest1.CompareTo(new object()));
        }

        [Fact]
        public void Restaurant_CompareTo_ShoulReturnTrue()
        {
            //Arrange
            var rest1 = new Restaurant { Id = Guid.NewGuid(), Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };
            int expected = 0;
           //Act
           int actual = rest1.CompareTo(rest1);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Restaurant_CompareTo_ShouldReturnFalse()
        {
            //Arrange
            var rest1 = new Restaurant { Id = Guid.NewGuid(), Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };
            var rest2 = new Restaurant { Id = Guid.NewGuid(), Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest2" };
            int expected = 0;
            //Act
            int actual = rest1.CompareTo(rest2);
            //Assert
            //Assert.Equal(expected, actual);
            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [ClassData(typeof(RestaurantData2))]
        public void Restaurant_Equals_ShouldWork(Restaurant rest1, Restaurant rest2, bool expected)
        {
            //Arrange
            //Restaurant rest1 = (Restaurant)obj[0];
            //Restaurant rest2 = (Restaurant)obj[1];
            //bool expected = (bool)obj[2];
            //Act
            bool Bool = rest1.Equals(rest2);

            //Assert
            Assert.Equal(expected, Bool);
        }
    }

    //public class RestaurantData : IEnumerable<object[]>
    //{
    //    public IEnumerator<object[]> GetEnumerator()
    //    {
    //        yield return new object[]
    //        {
    //            new Restaurant { Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" }, null, false 
    //        };
    //    }
    //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    //    //new List<object[]>
    //    //{
    //    //    new object[]{ new Restaurant { Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" }, null, false }
    //    //};
    //}

    public class RestaurantData2 : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Restaurant { Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" },
                null,
                false 
            };

            var rest1 = new Restaurant { Id = new Guid(), Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" };

            yield return new object[]
            {
                rest1,
                rest1,
                true
            };

            yield return new object[]
            {
                new Restaurant { Id = Guid.NewGuid(), Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest1" },
                new Restaurant { Id = Guid.NewGuid(), Adress = "s", City = "Vilnius", PictureUrl = "empty", Title = "rest2" },
                false
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
