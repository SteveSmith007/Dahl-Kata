using System.Collections.Generic;
using Bookstore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// A test class to test the scenario specifically describe in the kata brief.
    /// </summary>
    [TestClass]
    public class MainScenarioTests
    {
        [TestMethod]
        public void Basket_With_A_Bundle_Of_Five_Books_And_A_Bundle_Of_Three_Books_Costs_51_Eur_60_Cents()
        {
            //Arrange
            var bookBundleRules = new Dictionary<int, decimal>()
            {
                {2, 0.05M},
                {3, 0.1M},
                {4, 0.2M},
                {5, 0.25M},
            };

            var basket = new Basket(bookBundleRules);

            //Act
            basket.Add(item: new Book(code: 1), qty: 2);
            basket.Add(item: new Book(code: 2), qty: 2);
            basket.Add(item: new Book(code: 3), qty: 2);
            basket.Add(item: new Book(code: 4));
            basket.Add(item: new Book(code: 5));

            //Assert
            Assert.AreEqual(expected: 51.60M, actual: basket.Total);
        }
    }
}