using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
   

        public interface IAuthorService
        {
            Task AddAuthorAsync(Author author);
            Task UpdateAuthorAsync(Author author);
            Task DeleteAuthorAsync(int id);
            Task<Author> GetAuthorByIdAsync(int id);
            Task<IEnumerable<Author>> GetAllAuthorsAsync();
        }
    }


