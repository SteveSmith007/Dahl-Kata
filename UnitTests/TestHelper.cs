using System;
using System.Security.Cryptography;

namespace UnitTests
{
    public static class TestHelper
    {
        public static int RandomInteger(int value1, int value2) => new Random(Seed: new Guid().GetHashCode()).Next(Math.Min(value1, value2), Math.Max(value1, value2));

        public static decimal RandomPrice(decimal value1, decimal value2)
        {
            return Math.Round(RandomDecimal(value1, value2));
        }

        private static decimal RandomDecimal(decimal value1, decimal value2)
        {
            var min = Math.Min(value1, value2);
            var range = Math.Abs(value1 - value2);

            return min + range * (decimal)new Random(Seed: Guid.NewGuid().GetHashCode()).NextDouble();
        }

    }
}