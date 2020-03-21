using System;
using System.Collections.Generic;
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
            var basket = new Basket(new Dictionary<int, decimal>
                {
                    {2, .05M},
                }
            );
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

        [TestMethod]
        public void Baskets_With_Three_Different_Copies_Of_Roald_Dahl_Books_Costs_10PC_Less_Than_Buying_The_Single_Copies()
        {
            //Arrange
            var basket = new Basket(new Dictionary<int, decimal>
                {
                    {3, .1M},
                }
            );
            var book1 = new Book(code: 1);
            var book2 = new Book(code: 2);
            var book3 = new Book(code: 3);
            var expectedPrice = (book1.Price + book2.Price + book3.Price) * .9M;

            //Act
            basket.Add(item: book1);
            basket.Add(item: book2);
            basket.Add(item: book3);

            //Assert
            Assert.AreEqual(expected: 3, actual: basket.Items.Count);
            Assert.AreEqual(expected: expectedPrice, actual: basket.Total);
        }

        [TestMethod]
        public void Baskets_With_Four_Different_Copies_Of_Roald_Dahl_Books_Costs_20PC_Less_Than_Buying_The_Single_Copies()
        {
            //Arrange
            var basket = new Basket(new Dictionary<int, decimal>
                {
                    {4, .2M},
                }
            );
            var book1 = new Book(code: 1);
            var book2 = new Book(code: 2);
            var book3 = new Book(code: 3);
            var book4 = new Book(code: 4);
            var expectedPrice = (book1.Price + book2.Price + book3.Price + book4.Price) * .8M;

            //Act
            basket.Add(item: book1);
            basket.Add(item: book2);
            basket.Add(item: book3);
            basket.Add(item: book4);

            //Assert
            Assert.AreEqual(expected: 4, actual: basket.Items.Count);
            Assert.AreEqual(expected: expectedPrice, actual: basket.Total);
        }

        [TestMethod]
        public void Baskets_With_Five_Different_Copies_Of_Roald_Dahl_Books_Costs_25PC_Less_Than_Buying_The_Single_Copies()
        {
            //Arrange
            var basket = new Basket(new Dictionary<int, decimal>
                {
                    {5, .25M},
                }
            );
            var book1 = new Book(code: 1);
            var book2 = new Book(code: 2);
            var book3 = new Book(code: 3);
            var book4 = new Book(code: 4);
            var book5 = new Book(code: 5);
            var expectedPrice = (book1.Price + book2.Price + book3.Price + book4.Price + book5.Price) * .75M;

            //Act
            basket.Add(item: book1);
            basket.Add(item: book2);
            basket.Add(item: book3);
            basket.Add(item: book4);
            basket.Add(item: book5);

            //Assert
            Assert.AreEqual(expected: 5, actual: basket.Items.Count);
            Assert.AreEqual(expected: expectedPrice, actual: basket.Total);
        }

        [TestMethod]
        public void Baskets_Containing_Items_Other_Than_Books_Costs_Same_As_Sum_Of_Individual_Items()
        {
            //Arrange
            var basket = new Basket();
            var item1 = new Item(price: TestHelper.RandomPrice(0M, 100M));
            var item2 = new Item(price: TestHelper.RandomPrice(0M, 100M));
            var expectedPrice = item1.Price + item2.Price;

            //Act
            basket.Add(item: item1);
            basket.Add(item: item2);

            //Assert
            Assert.AreEqual(expected: 2, actual: basket.Items.Count);
            Assert.AreEqual(expected: expectedPrice, actual: basket.Total);
        }

        [TestMethod]
        public void Baskets_Of_Both_Items_And_Books_Of_Same_Type_Costs_Same_As_Sum_Of_Individual_Items()
        {
            //Arrange
            var basket = new Basket();
            var book1 = new Book(code: 1);
            var item1 = new Item(price: TestHelper.RandomPrice(0M, 100M));
            var item2 = new Item(price: TestHelper.RandomPrice(0M, 100M));
            var expectedPrice = (2 * book1.Price + item1.Price + item2.Price);

            //Act
            basket.Add(item: book1, qty: 2);
            basket.Add(item: item1);
            basket.Add(item: item2);

            //Assert
            Assert.AreEqual(expected: 4, actual: basket.Items.Count);
            Assert.AreEqual(expected: expectedPrice, actual: basket.Total);
        }

    }
}
