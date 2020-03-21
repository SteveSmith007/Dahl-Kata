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
        public decimal Total
        {
            get
            {
                var total = 0M;

                var bookBundles = new List<HashSet<Book>>();

                foreach (var item in Items)
                {
                    if (!(item is Book book)) //item is not a book}
                    {
                        total += item.Price;
                        continue;
                    }

                    var added = false;

                    foreach (var bookBundle in bookBundles.Where(bookBundle => bookBundle.Count < 2))
                    {
                        added = bookBundle.Add(book);
                    }

                    if (!added) //Start a new bundle
                    {
                        bookBundles.Add(new HashSet<Book>() { book });
                    }

                }

                foreach (var bookBundle in bookBundles)
                {
                    if (bookBundle.Count == 2)
                    {
                        total += bookBundle.Sum(book => book.Price) * .95M;
                    }
                    else
                    {
                        total += bookBundle.Sum(book => book.Price);
                    }
                }

                return total;
            }
        }

        public void Add(IItem item, int qty = 1)
        {
            for (var i = 0; i < qty; i++)
                Items.Add(item);
        }
    }
}