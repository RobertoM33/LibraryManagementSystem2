using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IBookService
    {
        public interface IAuthorService
        {
            Task AddBookAsync(Book book);
            Task UpdateBookAsync(Book book);
            Task DeleteBookAsync(string isbn);
            Task<Book> GetBookByISBNAsync(string isbn);
            Task<IEnumerable<Book>> GetAllBooksAsync();
            Task<IEnumerable<Book>> SearchBooksAsync(string title, string author, Category? category);
            Task<IEnumerable<Book>> GetPopularBooksAsync();
        }
    }
}

