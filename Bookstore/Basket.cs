using System.Collections.Generic;
using System.Linq;

namespace Bookstore
{
    public class Basket
    {
        private readonly Dictionary<int, decimal> _bookBundleDiscounts;

        public IList<IItem> Items { get; }

        public Basket(Dictionary<int, decimal> bookBundleDiscounts = null)
        {
            _bookBundleDiscounts = bookBundleDiscounts ?? new Dictionary<int, decimal>();

            Items = new List<IItem>();
        }

        public decimal Total => BookSubTotal + OtherItemSubTotal;

        private decimal OtherItemSubTotal => Items.Where(item => !(item is Book)).Sum(item => item.Price);

        private decimal BookSubTotal
        {
            get
            {
                var books = new List<Book>();

                foreach (var item in Items)
                {
                    if (item is Book book)
                        books.Add(book);
                }

                var bookBundles = new List<HashSet<Book>>();

                foreach (var book in books)
                {
                    var added = false;

                    foreach (var bookBundle in bookBundles.Where(bookBundle =>
                        bookBundle.Count < (_bookBundleDiscounts.Keys.Count > 0 ? _bookBundleDiscounts.Keys.Max() : 1)))
                    {
                        if (added) continue;

                        added = bookBundle.Add(book);
                    }

                    if (!added) //Start a new bundle
                        bookBundles.Add(new HashSet<Book>() { book });

                }

                return bookBundles.Sum(bookBundle => bookBundle.Sum(book => book.Price) * (1M - (_bookBundleDiscounts.ContainsKey(bookBundle.Count)
                                                                                               ? _bookBundleDiscounts[bookBundle.Count]
                                                                                               : 0M)));
            }
        }

        public void Add(IItem item, int qty = 1)
        {
            for (var i = 0; i < qty; i++)
                Items.Add(item);
        }
    }
}