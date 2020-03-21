using System.Collections.Generic;
using System.Linq;

namespace Bookstore
{
    public class Basket
    {
        public Basket()
        {
            Items = new List<IItem>();
        }

        public IList<IItem> Items { get; }
        public decimal Total => Items?.Sum(item => item.Price) ?? 0M;

        public void Add(Book book)
        {
            Items.Add(book);
        }
    }
}