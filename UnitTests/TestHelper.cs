using System;
using System.Security.Cryptography;

namespace UnitTests
{
    public static class TestHelper
    {
        public static int RandomInteger(int value1, int value2) => new Random(Seed: new Guid().GetHashCode()).Next(Math.Min(value1, value2), Math.Max(value1, value2));
    }
}