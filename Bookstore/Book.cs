using System.Collections.Generic;

namespace Bookstore
{
    public class Book : IItem
    {
        public decimal Price => 8M;

        public int Code { get; }

        public Book(int code)
        {
            Code = code;
        }
    }
}