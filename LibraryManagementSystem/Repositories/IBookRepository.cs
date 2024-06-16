using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
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
