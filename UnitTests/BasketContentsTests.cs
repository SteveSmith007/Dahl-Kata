using System;
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
        public void Basket_With_Only_Copies_Of_First_Roald_Dahl_Book_Costs_That_Of_Buying_As_Many_Single_Copies()
        {
            //Arrange
            var basket = new Basket();
            var book = new Book(code: 1);

            //Act
            for (var i = 1; i <= 5; i++)
            {
                //Act
                basket.Add(book);

                //Assert
                Assert.AreEqual(expected: i, actual: basket.Items.Count);
                Assert.AreEqual(expected: i * 8, actual: basket.Total);
            }
        }
    }
}
