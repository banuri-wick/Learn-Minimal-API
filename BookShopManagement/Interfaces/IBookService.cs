using BookShopManagement.Models;

namespace BookShopManagement.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        void CreateBooks(Request request);
        void UpdateBook(Book updatedBook);
    }
}
