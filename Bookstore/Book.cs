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

        public override bool Equals(object obj)
        {
            return obj != null && ((Book)obj).Code == Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }
    }
}