using Dapper;
using LibraryManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly string _connectionString;
        public LoanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddLoanAsync(Loan loan)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "INSERT INTO Loans (BookISBN, MemberId, LoanDate, ReturnDate) VALUES (@BookISBN, @MemberId, @LoanDate, @ReturnDate)";
            await connection.ExecuteAsync(query, loan);
        }

        public async Task UpdateLoanAsync(Loan loan)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "UPDATE Loans SET BookISBN = @BookISBN, MemberId = @MemberId, LoanDate = @LoanDate, ReturnDate = @ReturnDate WHERE Id = @Id";
            await connection.ExecuteAsync(query, loan);
        }

        public async Task DeleteLoanAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "DELETE FROM Loans WHERE Id = @Id";
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Loans WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Loan>(query, new { Id = id });
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Loans";
            return await connection.QueryAsync<Loan>(query);
        }
    }
}
