using LibraryManagementSystem.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LibraryManagementSystem.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly string _connectionString;

        public AuthorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAuthorAsync(Author author)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "INSERT INTO Authors (FirstName, LastName, BirthYear) VALUES (@FirstName, @LastName, @BirthYear)";
            await connection.ExecuteAsync(query, author);


        }

        public async Task UpdateAuthorAsync(Author author)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName, BirthYear = @BirthYear WHERE Id = @Id";
            await connection.ExecuteAsync(query, author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "DELETE FROM Authors WHERE Id = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Authors WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Author>(query, new { Id = id });
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Authors";
            return await connection.QueryAsync<Author>(query);
        }
    }
}

