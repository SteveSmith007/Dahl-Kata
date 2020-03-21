﻿using System;
using System.Linq;
using Bookstore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BasketContentsTests
    {
        [TestMethod]
        public void Basket_With_Nothing_In_Has_A_Total_Of_0()
        {
            //Arrange
            var basket = new Basket();

            //Act
            var total = basket.Total;

            //Assert
            Assert.AreEqual(expected: 0, actual: total);
        }

        [TestMethod]
        public void Basket_With_One_Copy_Of_First_Roald_Dahl_Book_Costs_8_Eur()
        {
            //Arrange
            var basket = new Basket();

            //Act
            basket.Add(new Book(code: 1));

            //Assert
            Assert.AreEqual(expected: 1, actual: basket.Items.Count);
            Assert.AreEqual(expected: 8, actual: basket.Total);
        }
    }
}
