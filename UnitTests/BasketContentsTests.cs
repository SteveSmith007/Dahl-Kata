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

    }
}
