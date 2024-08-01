using System.Diagnostics;

namespace Assignment13
{
    internal class Program
    {
        public static void ProcessBooks<T>(List<Book> books, Func<Book, T> fPtr)
        {
            foreach (Book book in books)
            {
                Console.WriteLine(fPtr(book));
            }
        }

        static void Main(string[] args)
        {
            #region
            Book book1 = new("isbn1", "title1", ["author1","author2"],DateTime.Now,30);
            Book book2 = new("isbn2", "title2", ["author2", "author3"], DateTime.Now, 30);

            var books = new List<Book> { book1, book2 };
            var bookFunctions = new BookFunctions();
            var bookProcessor = new LibraryEngine();

            ProcessBooks(books, BookFunctions.GetTitle);
            ProcessBooks(books, BookFunctions.GetAuthors);
            ProcessBooks(books, BookFunctions.GetPrice);

            //anonymous
            Func<Book, string> GetISBN = delegate (Book book) { return book.ISBN; };
            ProcessBooks(books, GetISBN);

            //lambda
            ProcessBooks(books, (b) => b.PublicationDate);
            #endregion

        }
    }
}
