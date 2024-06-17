using Dapper;
using LibraryManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        //using var connection = new SqlConnection(_connectionString);
        //var query = "INSERT INTO Automobiliai (Marke, Modelis, Metai, RegistracijosNumeris) OUTPUT INSERTED.Id VALUES (@Marke, @Modelis, @Metai, @RegistracijosNumeris)";
        //return await connection.QuerySingle<int>(query, automobilis);
        public async Task AddBookAsync(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "INSERT INTO Books (ISBN, Title, PublicationYear, Category, Status) VALUES (@ISBN, @Title, @PublicationYear, @Category, @Status)";
            await connection.ExecuteAsync(query, book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "UPDATE Books SET Title = @Title, PublicationYear = @PublicationYear, Category = @Category, Status = @Status WHERE ISBN = @ISBN";
            await connection.ExecuteAsync(query, book);
        }

        public async Task DeleteBookAsync(string isbn)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "DELETE FROM Books WHERE ISBN = @ISBN";
            await connection.ExecuteAsync(query, new { ISBN = isbn });
        }

        public async Task<Book> GetBookByISBNAsync(string isbn)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Books WHERE ISBN = @ISBN";
            return await connection.QueryFirstOrDefaultAsync<Book>(query, new { ISBN = isbn });
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Books";
            return await connection.QueryAsync<Book>(query);
        }
        public async Task<IEnumerable<Book>> SearchBooksAsync(string title, string author, Category? category)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
            SELECT b.* FROM Books b
            INNER JOIN BookAuthors ba ON b.ISBN = ba.BookISBN
            INNER JOIN Authors a ON ba.AuthorId = a.Id
            WHERE (@Title IS NULL OR b.Title LIKE '%' + @Title + '%')
            AND (@Author IS NULL OR (a.FirstName + ' ' + a.LastName) LIKE '%' + @Author + '%')
            AND (@Category IS NULL OR b.Category = @Category)";
            return await connection.QueryAsync<Book>(query, new { Title = title, Author = author, Category = category });
        }

        public async Task<IEnumerable<Book>> GetPopularBooksAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
            SELECT b.*, COUNT(l.Id) AS LoanCount
            FROM Books b
            INNER JOIN Loans l ON b.ISBN = l.BookISBN
            GROUP BY b.ISBN, b.Title, b.PublicationYear, b.Category, b.Status
            ORDER BY LoanCount DESC";
            return await connection.QueryAsync<Book>(query);
        }
    }
}



