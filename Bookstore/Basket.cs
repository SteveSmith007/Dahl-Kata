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

                var subTotal = 0M;

                var bookBundles = new List<HashSet<Book>>();

                foreach (var book in books)
                {
                    var added = false;

                    foreach (var bookBundle in bookBundles.Where(bookBundle => bookBundle.Count < 2))
                        added = bookBundle.Add(book);

                    if (!added) //Start a new bundle
                        bookBundles.Add(new HashSet<Book>() { book });

                }

                foreach (var bookBundle in bookBundles)
                {
                    if (bookBundle.Count == 2)
                        subTotal += bookBundle.Sum(book => book.Price) * .95M;
                    else
                        subTotal += bookBundle.Sum(book => book.Price);
                }

                return subTotal;
            }
        }

        public void Add(IItem item, int qty = 1)
        {
            for (var i = 0; i < qty; i++)
                Items.Add(item);
        }
    }
}