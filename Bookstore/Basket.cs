using System.Collections.Generic;

namespace Bookstore
{
    public class Basket
    {
        public Basket()
        {
            Items = new List<IItem>();
        }

        public IList<IItem> Items { get; }
    }
}