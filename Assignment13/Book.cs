using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment13
{
    public delegate string BookDelegate(Book book);

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string iSBN, string title, string[] authors, DateTime publicationDate, decimal price)
        {
            ISBN = iSBN;
            Title = title;
            Authors = authors;
            PublicationDate = publicationDate;
            Price = price;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Authors: {Authors}, PublicationDate: {PublicationDate}, Price: {Price}";
        }
    }

    public class BookFunctions
    {
        public static string GetTitle(Book book)
        {
            return book.Title;
        }

        public static string[] GetAuthors(Book book)
        {
            return book.Authors;
        }

        public static decimal GetPrice(Book book)
        {
            return book.Price;
        }

        public string GetISBN(Book book)
        {
            return book.ISBN;
        }

        public DateTime GetPublicationDate(Book book)
        {
            return book.PublicationDate;
        }
    }

    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> booksList, BookDelegate bookDelegate)
        {
            foreach (Book book in booksList)
            {
                Console.WriteLine(bookDelegate(book));    
            }
        }

        public void ProcessBooks<T>(List<Book> books, Func<Book, T> fPtr)
        {
            foreach (var book in books)
            {
                Console.WriteLine(fPtr(book));
            }
        }
        
    }
}