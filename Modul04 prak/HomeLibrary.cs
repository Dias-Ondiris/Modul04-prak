using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul04_prak
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Ganre { get; set; }
        public int CountPages { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PublicationYear { get {
                return PublicationDate.Year;
            } 
        }



    }
    public class HomeLibrary
    {
        private List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }
        public IEnumerable<Book> FindByAuthor(string author)
        {
            return books.Where(b => b.Author == author);
        }
        public IEnumerable<Book> FindByPublicationYear(int year)
        {
            return books.Where(b => b.PublicationYear == year);
        }
        public IEnumerable<Book> SortByTitle()
        {
            return books.OrderBy(b => b.Title);
        }
        public IEnumerable<Book> SortByAuthor()
        {
            return books.OrderBy(b => b.Author);
        }
        public Book FindByTitle(string title)
        {
            return books.FirstOrDefault(b => b.Title == title);
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }
        public bool RemoveBookByTitle(string title)
        {
            var book = FindByTitle(title);
            if (book != null)
            {
                books.Remove(book);
                return true; 
            }
            return false;
        }
        public IEnumerable<Book> SortByPublicationYear()
        {
            return books.OrderBy(b => b.PublicationYear);
        }
    }
}
