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
        public void Basket_With_Only_Copies_Of_Same_Roald_Dahl_Book_Costs_That_Of_Buying_As_Many_Single_Copies()
        {
            for (var i = 1; i <= 5; i++)
            {
                //Arrange
                var basket = new Basket();
                var qtyToAdd = TestHelper.RandomInteger(1, 100);
                var book = new Book(code: i);

                //Act
                basket.Add(item: book, qty: qtyToAdd);

                //Assert
                Assert.AreEqual(expected: qtyToAdd, actual: basket.Items.Count);
                Assert.AreEqual(expected: qtyToAdd * book.Price, actual: basket.Total);
            }
        }

        [TestMethod]
        public void Baskets_With_Two_Different_Copies_Of_Roald_Dahl_Books_Costs_5PC_Less_Than_Buying_The_Single_Copies()
        {
            //Arrange
            var basket = new Basket();
            var book1 = new Book(code: 1);
            var book2 = new Book(code: 2);
            var expectedPrice = (book1.Price + book2.Price) * .95M;

            //Act
            basket.Add(book1);
            basket.Add(book2);

            //Assert
            Assert.AreEqual(expected: 2, actual: basket.Items.Count);
            Assert.AreEqual(expected: expectedPrice, actual: basket.Total);
        }
    }
}
