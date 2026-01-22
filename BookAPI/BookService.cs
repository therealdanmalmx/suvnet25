using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI
{
    public class BookService(IBookRepository _bookRepository)
    {
        public void NewBook(string Title, string Author, int Year)
        {
            _bookRepository.AddNewBook(new Book {Title = Title, Author = Author, Year = Year});
        }
    }

    public interface IBookRepository
    {
        void AddNewBook(Book b);
    }

    public class BookRepository : IBookRepository
    {
        public void AddNewBook(Book b)
        {

        }
    }
}