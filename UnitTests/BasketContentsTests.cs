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
        public void Baskets_With_Single_Bundle_Of_Different_Copies_Of_Roald_Dahl_Books_Has_Discount_Applied()
        {
            //Arrange
            var discount = TestHelper.RandomDiscount();
            var bundleSize = TestHelper.RandomInteger(1, 100);
            var expectedPrice = 0M;

            var basket = new Basket(new Dictionary<int, decimal>
                {
                    {bundleSize, discount},
                }
            );

            for (int i = 1; i <= bundleSize; i++)
            {
                //Arrange
                var book = new Book(code: i);
                expectedPrice += book.Price;

                //Act
                basket.Add(book);
            }

            expectedPrice*=(1M-discount);

            //Assert
            Assert.AreEqual(expected: bundleSize, actual: basket.Items.Count);
            Assert.AreEqual(expected: expectedPrice, actual: basket.Total);
        }

        [TestMethod]
        public void Baskets_With_Multiple_Bundles_Of_Different_Copies_Of_Roald_Dahl_Books_Has_Discounts_Applied()
        {
            //Arrange
            var bundleRules = new Dictionary<int, decimal>();
            var books = new List<Book>();
            var expectedPrice = 0M;

            var maxBundleSize = TestHelper.RandomInteger(1, 10);

            for (int i = 1; i < maxBundleSize; i++)
            {
                var discount = TestHelper.RandomDiscount();
                bundleRules.Add(i,discount);

                var bundlePrice = 0M;

                for (int j = 1; j <= i; j++)
                {
                    var book = new Book(code: j);
                    bundlePrice += book.Price;
                    books.Add(book);
                }
                
                expectedPrice += bundlePrice * (1M - discount);
            }
            
            var basket = new Basket(bundleRules);

            //Act
            foreach (var book in books)
                basket.Add(book);

            //Assert
            Assert.AreEqual(expected: books.Count, actual: basket.Items.Count);
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
