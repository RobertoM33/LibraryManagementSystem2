using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
    }
}
