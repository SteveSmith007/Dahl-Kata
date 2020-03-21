using System;
using System.Linq;
using Bookstore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Basket_Is_Empty_When_Created()
        {
            //Arrange
            var basket = new Basket();

            //Act
            var itemCount = basket.Items.Count;

            //Assert
            Assert.AreEqual(expected: 0, actual: itemCount);
        }

    }
}
