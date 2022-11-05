using BookShopManagement.Infranstructure;
using BookShopManagement.Interfaces;
using BookShopManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookShopManagement.Repositories
{
    public class BooksService : IBookService
    {
        private readonly ApiContext _context;

        public BooksService(ApiContext context) 
        {
            _context = context;
            seedBooks();
        }

        public void CreateBooks(Request request)
        {
            throw new NotImplementedException();
        }

        public void seedBooks() 
        {
            if (_context.Books.Any())
                return;

            _context.Books.AddRange(
                    new Book()
                    {
                        Id = 1,
                        Name = "Book 1",
                        Author = "Author 1",
                        Price = 200,
                        stocksAvailable = 5
                    },
                    new Book()
                    {
                        Id = 2,
                        Name = "Book 2",
                        Author = "Author 2",
                        Price = 150,
                        stocksAvailable = 2
                    }
                );
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                IEnumerable<Book> books = _context.Books; 
                return books;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
