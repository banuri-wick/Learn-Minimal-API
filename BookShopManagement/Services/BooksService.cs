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
                        Price = 200
                    },
                    new Book()
                    {
                        Id = 2,
                        Name = "Book 2",
                        Author = "Author 2",
                        Price = 150
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

        public void CreateBooks(Request request)
        {
            var newId = _context.Books.Count() + 1;
            _context.Books.Add(new Book()
            {
                Id = newId,
                Name = request.Name,
                Author = request.Author,
                Price = (double)request.Price
            });
            _context.SaveChanges();
        }

        public void UpdateBook(Book updatedBook)
        {
            var currentBookData = _context.Books.FirstOrDefault(x => x.Id == updatedBook.Id);

            if (currentBookData != null) 
            {
                currentBookData.Name = updatedBook.Name;
                currentBookData.Author = updatedBook.Author;
                currentBookData.Price = updatedBook.Price;
            }
            
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var bookToBeDeleted = _context.Books.FirstOrDefault(x => x.Id == id);

            if (bookToBeDeleted != null)
            {
                _context.Books.Remove(bookToBeDeleted);
                _context.SaveChanges();
            }
        }
    }
}
