using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(string isbn)
        {
            await _bookRepository.DeleteBookAsync(isbn);
        }

        public async Task<Book> GetBookByISBNAsync(string isbn)
        {
            return await _bookRepository.GetBookByISBNAsync(isbn);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string title, string author, Category? category)
        {
            return await _bookRepository.SearchBooksAsync(title, author, category);
        }

        public async Task<IEnumerable<Book>> GetPopularBooksAsync()
        {
            return await _bookRepository.GetPopularBooksAsync();
        }
    }
}
