using System.Collections.Generic;

namespace Bookstore
{
    public interface IItem
    {
        decimal Price { get; }
    }

    public class Item : IItem
    {
        public decimal Price { get; }

        public Item(decimal price)
        {
            Price = price;
        }
    }
}